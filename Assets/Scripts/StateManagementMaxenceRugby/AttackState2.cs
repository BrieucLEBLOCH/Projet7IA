using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState2 : State2
{
    //liste des states necessaire
    public IdleState2 idlestate;

    //Parametre pour determiner si on peut attaquer de nouveau ou non
    private bool Had_Attacked = false;
    public bool mode_charge = false;

    public float timeCoolDownAttack = 4;
    public float timeRemaining = 0;
    public float timecharge = 5;

    //pour la fireball
    private GameObject player;
    private float distance;

    private GameObject parentState;
    private Rigidbody2D rb2d;
    private Transform transformParent;


    public AudioClip audioCharge;
    public AudioSource _audioSource;

    public float moveSpeedCharge = 7f;


    private void Start()
    {
        player = GameObject.Find("/Player");
        parentState = this.transform.parent.gameObject;
        rb2d = parentState.GetComponentInParent<Rigidbody2D>();
        transformParent = parentState.GetComponentInParent<Transform>();
        _audioSource = this.GetComponent<AudioSource>();
    }

    public override State2 RunCurrentState()
    {
        //Debug.Log("State RunCurrentState");
        //s'il n'a pas encore attaqué 
        if (Had_Attacked == false)// && timeRemaining <= 0)
        {
            Debug.Log("Mode Attack");
            //lancement mode charge
            if (mode_charge == false)
            {
                _audioSource.Play();
                mode_charge = true;
                rb2d.velocity = rb2d.transform.up * 0; //le zombie est a l'arret
            }

            if (timecharge <= 0)
            {
                mode_charge_go();
                //StartCoroutine(WaitEndChargeZombie(2));
                // rb2d.velocity = rb2d.transform.up * 0; //le zombie est a l'arret
                timecharge = 5;
                timeRemaining = timeCoolDownAttack; //lancement du cooldown
                Had_Attacked = true;
            }
            return this;
        }
        else
        {
            //Debug.Log("Time Remaining = " + timeRemaining);
            if (timeRemaining <= 0)//il a deja attaqué et le cooldown est fini == on retourne au state idle
            {
                //Debug.Log("cooldown fini je retourne a idle");
                Had_Attacked = false;
                mode_charge = false;
                timeRemaining = timeCoolDownAttack;
         //       timecharge = 5;
                return idlestate;
            }
            else//cooldown non fini du coup on reste dans le state attack
            {
               // Debug.Log("je suis en cooldown");
                return this;
            }
        }
    }

    void mode_charge_go()
    {
        Debug.Log("je vais charger");
        if (player != null)
        {
            //rb2d.velocity = rb2d.transform.up * 0; //le zombie est a l'arret
            //Debug.Log("velocity = " + rb2d.velocity);
            Vector2 direction = (player.transform.position - transformParent.position).normalized;
            transformParent.transform.up = player.transform.position - transformParent.position;
            rb2d.velocity = transformParent.up * moveSpeedCharge;
            transformParent.rotation = new Quaternion(0, 0, 0, transformParent.rotation.w);
            //le zombie reste sur sa lancée pendant x secondes
        }
    }
    private IEnumerator WaitEndChargeZombie(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        mode_charge = false;
    }

    private void Update()
    {
        if (Had_Attacked == true)
            timeRemaining -= Time.deltaTime;
        if (mode_charge == true)
            timecharge -= Time.deltaTime;
    }
}
