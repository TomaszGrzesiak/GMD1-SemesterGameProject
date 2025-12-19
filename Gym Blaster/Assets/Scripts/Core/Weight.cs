using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public sealed class Weight : MonoBehaviour
{
    public float fuseSeconds = 4f;
    public int blastRange = 1;

    public Tilemap wallsTilemap;
    public Tilemap destructibleTilemap;

    public GameObject explosionPrefab;
    public LayerMask playerMask;

    private void Start()
    {
        StartCoroutine(FuseRoutine());
    }

    private IEnumerator FuseRoutine()
    {
        yield return new WaitForSeconds(fuseSeconds); // Suspends the coroutine execution for the given amount of seconds using scaled time.
        Explode();
        Destroy(gameObject);
    }

    private void Explode()
    {
        Vector3Int origin = destructibleTilemap.WorldToCell(transform.position);

        ExplodeCell(origin);

        ExplodeLine(origin, Vector3Int.right);
        ExplodeLine(origin, Vector3Int.left);
        ExplodeLine(origin, Vector3Int.up);
        ExplodeLine(origin, Vector3Int.down);
    }

    private void ExplodeLine(Vector3Int origin, Vector3Int dir)
    {
        for (int i = 1; i <= blastRange; i++)
        {
            Vector3Int cell = origin + dir * i;

            // Stop at indestructible wall
            if (wallsTilemap.HasTile(cell))
                break;

            // Hit this cell
            ExplodeCell(cell);

            // If destructible tile exists, destroy it and stop propagation
            if (destructibleTilemap.HasTile(cell))
            {
                destructibleTilemap.SetTile(cell, null);
                PickupSpawner.I.RevealAt(cell);
                break;
            }
        }
    }

    private void ExplodeCell(Vector3Int cell)
    {
        Vector3 world = destructibleTilemap.GetCellCenterWorld(cell);
        
        Instantiate(explosionPrefab, world, Quaternion.identity);

        // Kill check (no physics pushing possible)
        Collider2D hit = Physics2D.OverlapCircle((Vector2)world, 0.35f, playerMask);
        if (hit != null && hit.CompareTag("Player"))
        {
            GameState.I.Restart(); // or Destroy(hit.gameObject); // or 
        }
    }

    public void Init(Tilemap walls, Tilemap destructible, int range)
    {
        wallsTilemap = walls;
        destructibleTilemap = destructible;
        blastRange = range;
    }
}