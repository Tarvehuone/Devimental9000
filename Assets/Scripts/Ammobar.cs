using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammobar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxAmmo(int ammo)
    {
        slider.maxValue = ammo;
        slider.value = ammo;
    }
    public void SetAmmo(int ammo)
    {
        slider.value = ammo;
    }
}
