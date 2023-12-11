using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    [SerializeField] Slider slider;

    // Update is called once per frame
    void Update()
    {

    }

    public void XPBarUpdate(float XP, float maxXP)
    {
        slider.maxValue = maxXP;
        slider.value = XP;
    }
}
