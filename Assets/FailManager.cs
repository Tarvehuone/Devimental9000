using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailManager : MonoBehaviour
{
    public GameObject canvas;
    public void DeathScreen()
    {
        canvas.SetActive(true);
    }
}
