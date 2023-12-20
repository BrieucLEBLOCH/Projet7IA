using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlUpScreenController : MonoBehaviour
{
    private Player player;
    [SerializeField]
    GameObject WeaponProjectileBtn, NewWeaponBtn;
    void Start()
    {
        player = GameObject.Find("/Player").GetComponent<Player>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void MaxHP()
    {
        player.HPLevelUp();
        gameObject.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }

    public void WeaponSpeed()
    {
        float f = player.GetWeaponSpeed();
        f += 0.2f;
        player.SetWeaponSpeed(f);
        gameObject.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }

    public void DmgBonus()
    {
        player.SetDmgBonus(player.GetDmgBonus() + 2);
        gameObject.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }

    public void Speed()
    {
        player.SpeedLevelUp();
        gameObject.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }

    public void WeaponProjectiles()
    {
        int i = player.GetWeaponProjectiles();
        player.SetWeaponProjectiles(i *= 2);
        gameObject.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
        if (player.GetWeaponProjectiles() >= 4)
        {
            Destroy(WeaponProjectileBtn);
        }
    }

    public void WeaponNumber()
    {
        player.SetWeaponNumber(player.GetWeaponNumber() + 1);
        gameObject.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
        if (player.GetWeaponNumber() >= 2)
        {
            Destroy(NewWeaponBtn);
        }
    }
}
