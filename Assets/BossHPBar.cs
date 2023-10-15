using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPBar : MonoBehaviour
{
    public Slider hpSlider;

    public void UpdateHP(int hitpoints)
    {
        hpSlider.value = hitpoints;
    }
}
