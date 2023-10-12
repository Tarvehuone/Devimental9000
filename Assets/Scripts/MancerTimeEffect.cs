using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MancerTimeEffect : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Player player = collider.gameObject.GetComponent<Player>();
            player.moveSpeed = 3;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Player player = collider.gameObject.GetComponent<Player>();
            player.moveSpeed = 6;
        }
    }
}
