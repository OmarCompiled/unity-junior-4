using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    private InputActionMap playerActionMap;
    private InputAction moveAction;
    private Rigidbody rigidbody;
    private Transform focalPoint;

    void OnEnable()
    {
        moveAction?.Enable();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        playerActionMap = InputSystem.actions.FindActionMap("Player");
        moveAction = playerActionMap.FindAction("Move");
        moveAction.Enable();

        focalPoint = GameObject.Find("FocalPoint").transform; // Very expensive, could replace by manual calculation
        // or maybe even serialize it if necessary.
    }

    void FixedUpdate()
    {
      ProcessMovement(Time.fixedDeltaTime);  
    }
    
    void Update()
    {
        if(transform.position.y < -20.0f)
        {
            GameManager.Instance.GameOver = true;
        }
    }

    void ProcessMovement(float deltaTime)
    {
        Vector2 movementInput = moveAction.ReadValue<Vector2>();
        Vector3 movement;
        if(!GameManager.Instance.LockCamera)
        {
            movement = focalPoint.forward * movementInput.y;
        }
        else
        {
            movement = (focalPoint.forward * movementInput.y) + (focalPoint.right * movementInput.x);
        }
        movement /= 4.0f * deltaTime;
        rigidbody.AddForce(movement);
    }

    void OnDisable()
    {
        moveAction?.Disable();
    }
}
