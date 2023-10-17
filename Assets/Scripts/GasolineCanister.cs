using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasolineCanister : MonoBehaviour
{
    public AudioClip pickUpSound;
    private AudioSource lootAudio;
    void Start()
    {
        lootAudio = GameObject.FindWithTag("LootAudio").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            collider.gameObject.GetComponent<Player>().flameThrower.GetComponent<FlameThrower>().ammo += 100;
            lootAudio.PlayOneShot(pickUpSound);
            Destroy(gameObject);
        }
    }
}
