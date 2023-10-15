using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBucket : MonoBehaviour
{
    private AudioSource slurps;
    public AudioClip slurpsClip;

    void Start()
    {
        slurps = GameObject.FindWithTag("LootAudio").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            slurps.PlayOneShot(slurpsClip);
            GetComponent<SpriteRenderer>().sprite = null;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, 1f);
        }
    }
}
