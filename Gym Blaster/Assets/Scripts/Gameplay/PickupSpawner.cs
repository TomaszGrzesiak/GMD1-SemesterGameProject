using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PickupSpawner : MonoBehaviour
{
    public static PickupSpawner I { get; private set; }

    [SerializeField] private Tilemap destructibleTilemap;
    [SerializeField] private PickupSpot[] spots;

    private readonly Dictionary<Vector3Int, PickupSpot> cellToSpot = new();
    private readonly HashSet<Vector3Int> revealed = new();

    private void Awake()
    {
        I = this;

        cellToSpot.Clear();
        foreach (var spot in spots)
        {
            if (spot == null || spot.PickupPrefab == null) continue;

            Vector3Int cell = destructibleTilemap.WorldToCell(spot.transform.position);
            
            cellToSpot[cell] = spot;
            
            spot.gameObject.SetActive(false);
        }
    }

    public void RevealAt(Vector3Int destroyedCell)
    {
        if (revealed.Contains(destroyedCell)) return;

        if (!cellToSpot.TryGetValue(destroyedCell, out var spot)) return;

        Vector3 world = destructibleTilemap.GetCellCenterWorld(destroyedCell);
        Instantiate(spot.PickupPrefab, world, Quaternion.identity);

        revealed.Add(destroyedCell);
    }
}
