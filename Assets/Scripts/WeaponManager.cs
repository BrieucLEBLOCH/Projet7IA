using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetWeaponNumber() == 1)
        {
            foreach (Transform t in gameObject.GetComponentsInChildren<Transform>(true))
            {
                if (t.gameObject.name == "Shovels")
                {
                    t.gameObject.SetActive(true);
                }
                else if (t.gameObject.name == "Scythes" || t.gameObject.name == "Shotguns")
                {
                    t.gameObject.SetActive(false);
                }
            }
        }
        else if (player.GetWeaponNumber() == 2)
        {
            foreach (Transform t in gameObject.GetComponentsInChildren<Transform>(true))
            {
                if (t.gameObject.name == "Shovels" || t.gameObject.name == "Scythes")
                {
                    t.gameObject.SetActive(true);
                }
                else if (t.gameObject.name == "Shotguns")
                {
                    t.gameObject.SetActive(false);
                }
            }
        }
        else if (player.GetWeaponNumber() == 3)
        {
            foreach (Transform t in gameObject.GetComponentsInChildren<Transform>(true))
            {
                if (t.gameObject.name == "Shovels" || t.gameObject.name == "Scythes" || t.gameObject.name == "Shotguns")
                {
                    t.gameObject.SetActive(true);
                }
            }
        }

        if (player.GetWeaponProjectiles() == 1)
        {
            foreach (Transform t in gameObject.GetComponentsInChildren<Transform>(false))
            {
                foreach (Transform t2 in t.gameObject.GetComponentsInChildren<Transform>(true))
                {
                    if (t2.gameObject.name == "1")
                    {
                        t2.gameObject.SetActive(true);
                    }
                    else if (t2.gameObject.name == "2" || t2.gameObject.name == "4")
                    {
                        t2.gameObject.SetActive(false);
                    }
                }
            }
        }
        else if (player.GetWeaponProjectiles() == 2)
        {
            foreach (Transform t in gameObject.GetComponentsInChildren<Transform>(false))
            {
                foreach (Transform t2 in t.gameObject.GetComponentsInChildren<Transform>(true))
                {
                    if (t2.gameObject.name == "2")
                    {
                        t2.gameObject.SetActive(true);
                    }
                    else if (t2.gameObject.name == "1" || t2.gameObject.name == "4")
                    {
                        t2.gameObject.SetActive(false);
                    }
                }
            }
        }
        else if (player.GetWeaponProjectiles() == 4)
        {
            foreach (Transform t in gameObject.GetComponentsInChildren<Transform>(false))
            {
                foreach (Transform t2 in t.gameObject.GetComponentsInChildren<Transform>(true))
                {
                    if (t2.gameObject.name == "4")
                    {
                        t2.gameObject.SetActive(true);
                    }
                    else if (t2.gameObject.name == "1" || t2.gameObject.name == "2")
                    {
                        t2.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
