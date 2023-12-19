using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateZf : StateZf
{
    //liste des states necessaire
    public IdleStateZf idlestate;

    //Parametre pour determiner si on peut attaquer de nouveau ou non
    private bool Had_Attacked = false;
    public float timeCoolDownAttack = 2;
    public float timeRemaining = 0;

    //pour la fireball
    [SerializeField] private GameObject PrefabFireBall;
    private GameObject player;
    [SerializeField] private float fireBallSpeed = 5;
    private float distance;


    private GameObject parentState;
    private Rigidbody2D rb2d;

    private void Start()
    {
        player = GameObject.Find("/Player");
        parentState = this.transform.parent.gameObject;
        rb2d = parentState.GetComponentInParent<Rigidbody2D>();
    }

    public override StateZf RunCurrentState()
    {
        //s'il n'a pas encore attaqué 
        if (Had_Attacked == false)// && timeRemaining <= 0)
        {
            //lancement de la fireball
            GameObject newFireBall = Instantiate(PrefabFireBall, parentState.transform.position, parentState.transform.rotation);

            newFireBall.transform.up = player.transform.position - newFireBall.transform.position;
            newFireBall.GetComponent<Rigidbody2D>().velocity = newFireBall.transform.up * fireBallSpeed;
            //barbare mais sinon bug quand on tir en bas pour bloquer la rotation
            newFireBall.transform.rotation = new Quaternion(0, 0, newFireBall.transform.rotation.z, newFireBall.transform.rotation.w);   
            //Debug.Log("j'attaque");
            Had_Attacked = true;
            timeRemaining = 2;
            return this;
        }
        else
        {
            if (timeRemaining <= 0)//il a deja attaqué et le cooldown est fini == on retourne au state idle
            {
                //Debug.Log("cooldown fini je retourne a idle");
                Had_Attacked = false;
                timeRemaining = timeCoolDownAttack;
                return idlestate;
            }
            else//cooldown non fini du coup on reste dans le state attack
            {
                //Debug.Log("je suis en cooldown");
                return this;
            }
        }
    }

    private void Update()
    {
        if (Had_Attacked == true)
            timeRemaining -= Time.deltaTime;
    }

}
