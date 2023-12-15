using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlUpScreenController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }


    }
}
