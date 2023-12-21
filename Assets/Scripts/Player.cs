using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField]
    private float maxSpeed = 5, currentSpeed = 0, acceleration = 50, deacceleration = 100, level = 1, XP = 0;
    [SerializeField]
    private float  speedMult = 1, weaponSpeed = 1;
    [SerializeField]
    private int maxHP = 10, HP = 10, dmgBonus = 0, weaponNumber = 1, weaponProjectiles = 1;
    private bool flipped = false, canTakeDmg = true;
    private float XPtolvlup = 10;
    [SerializeField]
    private InputActionReference movement;
    [SerializeField] HPBar HPB;
    [SerializeField] XPBar XPB;

    [SerializeField] private GameObject teleportPosition;

    private bool alreadyTeleported = false;

    public Vector2 movementInput { get; set; }
    private Vector2 oldMovementInput;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private SpriteRenderer spritePlayer;

    [SerializeField] Canvas lvlUP;

    [SerializeField] Text textHP;
    [SerializeField] Text textLevel;

    [SerializeField] private ParticleSystem bloodEffect;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        spritePlayer = GetComponent<SpriteRenderer>();
        bloodEffect = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        movementInput = movement.action.ReadValue<Vector2>();

        textHP.text = HP.ToString() + " / " + maxHP.ToString();
        textLevel.text = level.ToString();

        XPtolvlup = 10 * level;
        if (XP >= XPtolvlup)
        {
            XP -= XPtolvlup;
            level += 1;
            lvlUP.enabled = true;
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            XP += 1;
        }

        XPB.XPBarUpdate(XP, XPtolvlup);
        HPB.HPBarUpdate(HP, maxHP);

        if (level >= 7)
        {
            if (!alreadyTeleported)
            {
                TeleportPlayer();
                alreadyTeleported = true;
            }

            DestroyAllMonsters();
            DisableSpawners();
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
        rb2d.velocity = oldMovementInput * currentSpeed * speedMult;

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
            StartCoroutine(FeedBack(0.1f, 3.0f));
            spritePlayer.color = new UnityEngine.Color(1f, 0f, 0f, 1f);
            bloodEffect.Play();
        }

    }

    private IEnumerator FeedBack(float time, float blinkCount)
    {

        for (int i = 0; i < blinkCount; i++)
        {
            yield return new WaitForSeconds(time);
            spritePlayer.color = new UnityEngine.Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(time);
            spritePlayer.color = new UnityEngine.Color(1f, 0f, 0f, 1f);
        }

        spritePlayer.color = new UnityEngine.Color(1f, 1f, 1f, 1f);
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

    public void HPLevelUp()
    {
        maxHP += 5;
        HP += 5;
    }

    public void SpeedLevelUp()
    {
        speedMult += 0.2f;
    }

    public void SetWeaponProjectiles(int i)
    {
        weaponProjectiles = i;
    }

    public int GetWeaponProjectiles()
    {
        return weaponProjectiles;
    }

    public void SetDmgBonus(int i)
    {
        dmgBonus = i;
    }

    public int GetDmgBonus()
    {
        return dmgBonus;
    }

    public void SetWeaponSpeed(float f)
    {
        weaponSpeed = f;
    }

    public float GetWeaponSpeed()
    {
        return weaponSpeed;
    }

    public void SetWeaponNumber(int i)
    {
        weaponNumber = i;
    }

    public int GetWeaponNumber()
    {
        return weaponNumber;
    }

    public void SetHP(int i)
    {
        HP = i;
    }

    public int GetHP()
    {
        return HP;
    }

    public int GetMaxHp()
    {
        return maxHP;
    }
    private void TeleportPlayer()
    {
        transform.position = teleportPosition.transform.position;
    }

    private void DestroyAllMonsters()
    {
        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            Destroy(enemy.gameObject);
        }
    }

    private void DisableSpawners()
    {
        Spawner spawner = FindObjectOfType<Spawner>();

            spawner.StopSpawn();
    }
}