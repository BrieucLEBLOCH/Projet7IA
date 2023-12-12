using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class attackstatev2 : State
{
    public Transform player;
    public Transform Zombie;
    private Rigidbody2D rb2d;
    public float moveSpeedMonster = 5f;
    public bool safe_distance;
    public Move_F_Playerstate move_f_playerstate;


    public AudioClip sound;
    
    [Range(0.1f, 1f)]
    public float volume;

    [Range(0.1f, 2.5f)]
    public float pitch;

    private AudioSource source;

    public override State RunCurrentState()
    {

        if (distancePlayer() < 4f)
        {
            //UnityEngine.Debug.Log("j attaque le joueur");
            //zombie doit se rapprocher
            attack_player();
            return this;
        }
        else
            return move_f_playerstate; //sinon on revient au stade chasev2
    }
    void attack_player()
    {
        PlayAndPause();
        source.volume = volume;
        source.pitch = pitch;
    }

    private void Awake()
    {
        gameObject.AddComponent<AudioSource>();
        source = GetComponent<AudioSource>();
        volume = 0.5f;
        pitch = 1f;
    }


    float distancePlayer()
    {
        if (player != null)
        {
            Vector2 distance = player.transform.position - Zombie.transform.position;
            return (distance.magnitude);
        }
        return 0f;
    }

    private void Start()
    {
        source.clip = sound;
        source.volume = volume;
        source.pitch = pitch;
    }

    public void PlayAndPause()
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
        else
        {
            source.Pause();
        }
    }

}
