using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public InputAction MoveAction;
    public float playerSpeed = 4f;
    private Rigidbody2D rigidbody2d;
    private Vector2 move;
    
    // Added later to make animation of movement properly, where the player looks in the direction of walking
    //private Vector2 moveDirection = new Vector2(1, 0);
    
    private void OnEnable()
    {
        MoveAction.Enable();
    }

    private void OnDisable()
    {
        MoveAction.Disable();
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
}
