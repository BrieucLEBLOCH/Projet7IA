using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCD : MonoBehaviour
{
    [SerializeField] private int spawnCooldown;
    private float remainingCooldown;
    private bool isCooldown;
    // Start is called before the first frame update
    void Start()
    {
        isCooldown = false;
        remainingCooldown = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldown)
        {
            remainingCooldown -= Time.deltaTime;
            if (remainingCooldown <= 0.0f)
            {
                remainingCooldown = 0.0f;
                Debug.Log("not in cooldown");
                isCooldown = false;
            }
        }
        GetComponent<BossState>().SetCooldown(isCooldown);
    }

    public bool IsCooldown() { return isCooldown; }
    public void InCooldown() 
    {
        remainingCooldown = spawnCooldown;
        isCooldown = true;
    }
}
