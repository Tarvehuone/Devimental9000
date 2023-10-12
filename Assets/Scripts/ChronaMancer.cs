using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronaMancer : MonoBehaviour
{
    public GameObject mancerTimeEffect;

    public float nextAttackTime = 8f;
    private float nextTimer = 0f;
    private Transform player; // Reference to the player's Transform.

    public AudioSource attackAudio;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

            if (Time.time >= nextTimer)
            {
                attackAudio.Play();
                Instantiate(mancerTimeEffect, player.transform.position, Quaternion.identity);
                nextTimer = Time.time + Random.Range(nextAttackTime - 1, nextAttackTime + 1);
            }
        }
    }
}
