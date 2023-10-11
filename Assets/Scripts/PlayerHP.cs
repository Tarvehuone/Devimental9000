using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int hitpoints = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame 
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            hitpoints -= 5;
            Debug.Log("Player health: " + hitpoints);
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
