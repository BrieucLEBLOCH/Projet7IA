using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossState : MonoBehaviour
{
    [SerializeField] private int phaseBossState;
    [SerializeField] private float range;
    [SerializeField] public float HP;
    [SerializeField] public GameObject zombieKamikaze;
    [SerializeField] public GameObject zombieBDF;
    [SerializeField] public GameObject zombieNormal;

    public List<GameObject> zombies = new List<GameObject>();

    private bool isCooldown;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int GetPhase()
    {
        return phaseBossState;
    }

    public bool GetCooldown()
    {
        return isCooldown;
    }
    public float GetRange()
    {
        return range;
    }

    public void SetCooldown(bool pCooldown)
    {
        isCooldown = pCooldown;
    }


}
