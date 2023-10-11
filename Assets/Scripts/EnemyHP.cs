using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int hitpoints = 1000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Flame")
        {
            hitpoints -= 5;
            Debug.Log("Player health: " + hitpoints);
            EnemyDeath();
        }
    }

    void EnemyDeath()
    {
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
