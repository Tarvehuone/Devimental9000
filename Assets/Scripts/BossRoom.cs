using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    public GameObject door;
    public GameObject bossPrefab;
    public Transform bossSpawn;

    void Start()
    {
        door.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            door.SetActive(true);
            Instantiate(bossPrefab, bossSpawn.position, Quaternion.identity);
        }
    }
}
