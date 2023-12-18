using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField]
    private float maxSpeed = 5, currentSpeed = 0, acceleration = 50, deacceleration = 100, maxHP = 10, HP = 10, level = 1, XP = 0;
    private bool flipped = false, canTakeDmg = true;
    private float XPtolvlup = 10;
    [SerializeField]
    private InputActionReference movement;
    [SerializeField] HPBar HPB;
    [SerializeField] XPBar XPB;
    public Vector2 movementInput { get; set; }
    private Vector2 oldMovementInput;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] Canvas canvas;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        XPtolvlup = 10 * level;
        if (XP >= XPtolvlup)
        {
            XP -= XPtolvlup;
            level += 1;
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            XP += 1;
        }
        XPB.XPBarUpdate(XP, XPtolvlup);
        HPB.HPBarUpdate(HP, maxHP);
        movementInput = movement.action.ReadValue<Vector2>();

        if (HP <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
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

        Flip(rb2d.velocity.x);

        animator.SetFloat("Speed", currentSpeed);
    }

    private void Flip(float velocity)
    {
        if (velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
            flipped = false;
        }
        else if (velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
            flipped = true;
        }
    }

    public void AddXP()
    {
        XP += 1;
    }

    public void TakeDamage(int i)
    {
        if (canTakeDmg)
        {
            HP -= i;
            canTakeDmg = false;
            StartCoroutine(IFrame(0.5f));
        }

    }
    private IEnumerator IFrame(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canTakeDmg = true;
    }

    public bool GetFlipped()
    {
        return flipped;
    }
}
