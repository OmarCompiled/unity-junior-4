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

    void ProcessMovement(float deltaTime)
    {
        Vector2 movementInput = moveAction.ReadValue<Vector2>();
        Vector3 movement = focalPoint.forward * movementInput.y;
        movement /= deltaTime * 4.0f;
        rigidbody.AddForce(movement);
    }

    void OnDisable()
    {
        moveAction?.Disable();
    }
}
