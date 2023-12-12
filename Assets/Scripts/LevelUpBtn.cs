using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpBtn : MonoBehaviour
{
    private Button btnLevelUp;
    [SerializeField] GameObject canvas;

    void Start()
    {
        btnLevelUp = GetComponent<Button>();
        btnLevelUp.onClick.AddListener(CloseMenu);
    }

    void CloseMenu()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
    }
}
