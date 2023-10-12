using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronaMancer : MonoBehaviour
{
    public GameObject mancerTimeEffect;

    public float moveSpeed = 0.3f;
    public float nextAttackTime = 8f;
    private float nextTimer = 0f;
    private Transform player; // Reference to the player's Transform.
    private Rigidbody2D rb;

    public AudioSource attackAudio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;

            if (Time.time >= nextTimer)
            {
                attackAudio.Play();
                Instantiate(mancerTimeEffect, player.transform.position, Quaternion.identity);
                nextTimer = Time.time + Random.Range(nextAttackTime - 1, nextAttackTime + 1);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
