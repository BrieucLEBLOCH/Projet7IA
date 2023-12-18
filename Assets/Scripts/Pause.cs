using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseTxt;
    [SerializeField] GameObject ShovelRotateOFF;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pause");
            Time.timeScale = 0.0f;
            pauseTxt.SetActive(true);
            ShovelRotateOFF.GetComponent<ShovelRotate>().enabled = false;
        }
    }


    public void Continue()
    {
        Debug.Log("Unpause");
        Time.timeScale = 1.0f;
        pauseTxt.SetActive(false);
        ShovelRotateOFF.GetComponent<ShovelRotate>().enabled = true;
    }

    public void ReturnMenu(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
