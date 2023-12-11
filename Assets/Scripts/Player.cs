using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField]
    private float maxSpeed = 5, currentSpeed = 0, acceleration = 50, deacceleration = 100, maxHP = 10, HP = 10, level = 1, XP = 0;
    private float XPtolvlup = 10;
    [SerializeField]
    private InputActionReference movement;
    [SerializeField] HPBar HPB;
    [SerializeField] XPBar XPB;
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
        XPtolvlup = 10 * level;
        if (XP == XPtolvlup)
        {
            XP = 0;
            level += 1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            XP += 1;
        }
        XPB.XPBarUpdate(XP, XPtolvlup);
        HPB.HPBarUpdate(HP, maxHP);
        movementInput = movement.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (movementInput.magnitude > 0)
        {
            oldMovementInput = movementInput;
            currentSpeed += acceleration * maxSpeed * Time.deltaTime;
        }
        else
        {
            currentSpeed -= deacceleration * maxSpeed * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        rb2d.velocity = oldMovementInput * currentSpeed;
    }
}