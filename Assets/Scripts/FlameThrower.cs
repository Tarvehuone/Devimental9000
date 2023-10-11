using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    private Animator flameAnim;

    void Start()
    {
        flameAnim = GameObject.FindGameObjectWithTag("Flame").GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            flameAnim.SetTrigger("Shoot");
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            flameAnim.SetTrigger("Stop");
        }
    }
}
