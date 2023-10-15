using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    public GameObject door;
    public GameObject bossPrefab;
    public Transform bossSpawn;
    public GameObject bossHpBar;

    void Start()
    {
        door.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            door.SetActive(true);
            bossHpBar.SetActive(true);
            Instantiate(bossPrefab, bossSpawn.position, Quaternion.identity);
        }
    }
}
