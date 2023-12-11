using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] Slider slider;

    void Update()
    {

    }

    public void HPBarUpdate(float HP, float maxHP)
    {
        slider.maxValue = maxHP;
        slider.value = HP;
    }
}
