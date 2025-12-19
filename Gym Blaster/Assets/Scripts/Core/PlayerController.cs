using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    public float playerSpeed = 4f;
    private Rigidbody2D rigidbody2d;
    private Vector2 move;
    
    public InputAction PlaceAction;
    public Tilemap referenceTileMap;
    public GameObject weightPrefab;
    public LayerMask weightBlockingMask;
    public Tilemap wallsTilemap;
    public Tilemap  destructibleTilemap;
    public int blastRange = 2;

    
    // Added later to make animation of movement properly, where the player looks in the direction of walking
    //private Vector2 moveDirection = new Vector2(1, 0);
    
    private void OnEnable()
    {
        MoveAction.Enable();
        PlaceAction.Enable();
    }

    private void OnDisable()
    {
        MoveAction.Disable();
        PlaceAction.Disable();
    }
    
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        
        // two lines below: set the game to fixed 60 fps
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
        if (move.sqrMagnitude > 1f)
        {
            move = move.normalized;
        }

        if (PlaceAction.WasPressedThisFrame())
        {
            TryPlaceWeight();
        }
        
        // Added later to make animation of movement properly, where the player looks in the direction of walking
        // if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        // {
        //     moveDirection.Set(move.x, move.y);
        //     moveDirection.Normalize();
        // }
    }

    private void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d.position + move * (playerSpeed * Time.fixedDeltaTime);
        rigidbody2d.MovePosition(position);
    }

    private void TryPlaceWeight()
    {
        Vector3Int cell = referenceTileMap.WorldToCell(rigidbody2d.position);
        Vector3 worldCenter = referenceTileMap.GetCellCenterWorld(cell);

        Collider2D hit = Physics2D.OverlapCircle(worldCenter, 0.2f, weightBlockingMask);
        if (hit != null) return;

        var w = Instantiate(weightPrefab, worldCenter, Quaternion.identity)
            .GetComponent<Weight>();

        w.Init(wallsTilemap, destructibleTilemap, blastRange);
    }
}
