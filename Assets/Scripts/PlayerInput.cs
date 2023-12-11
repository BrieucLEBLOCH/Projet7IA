using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField]
    private float maxSpeed = 2, acceleration = 50, deacceleration = 100, currentSpeed = 0;
    [SerializeField]
    private InputActionReference movement;
    public Vector2 movementInput { get; set; }
    private Vector2 oldMovementInput;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = movement.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (movementInput.magnitude > 0 && currentSpeed >= 0)
        {
            oldMovementInput = movementInput;
            currentSpeed += deacceleration * maxSpeed * Time.deltaTime;
        }
        else
        {
            currentSpeed -= deacceleration * maxSpeed * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        rb2d.velocity = oldMovementInput * currentSpeed;
    }
}
