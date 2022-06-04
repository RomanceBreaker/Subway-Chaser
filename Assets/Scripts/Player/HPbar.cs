using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public float maxHP = 100f;
    public float currentHP = 100f;
    public float noteDamage = 5f;
    public Slider slider;

    public void Init()
    {
        slider.value = (float)1;
    }

    public float GetDamage()
    {
        currentHP -= noteDamage;
        slider.value = currentHP / maxHP;

        return currentHP;
    }
}
