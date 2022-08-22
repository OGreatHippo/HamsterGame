using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class xpBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxXP(int xp)
    {
        slider.maxValue = xp;
    }

    public void SetXP(int xp)
    {
        slider.value = xp;
    }
}
