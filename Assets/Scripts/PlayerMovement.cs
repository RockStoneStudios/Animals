using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float SpeedMovement = 11.6f;
    [SerializeField] private float xRange = 24;
    [SerializeField] private GameObject bullet;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction attackAction;
    private Vector2 inputs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        attackAction = playerInput.actions["Attack"];
    }

    // Update is called once per frame
    void Update()
    {
        inputs = moveAction.ReadValue<Vector2>();
        
        ClampPosition();

        // if(attackAction.WasPressedThisFrame()){
        //     Instantiate(bullet,transform.position,Quaternion.identity);
        // }
        
       
    }

     private void MovementPlayer(){
      
        transform.Translate(Vector3.right * inputs.x* SpeedMovement * Time.deltaTime);
     }


    private void ClampPosition()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -xRange, xRange);
        clampedPosition.y = 0f; // Mantener consistencia en Y
        
        if(transform.position != clampedPosition)
            transform.position = clampedPosition;
    }

    void FixedUpdate()
    {
        if(inputs != Vector2.zero){
             MovementPlayer();
        }
    }
}
