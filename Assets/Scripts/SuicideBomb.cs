using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideBomb : MonoBehaviour
{
    public float moveSpeed = 3f; // Adjust the movement speed as needed.
    public float detectionRadius = 5f;
    public float deathTimer = 3f;
    public LayerMask whatIsPlayer;
    private Animator explosionAnim;
    private Transform player; // Reference to the player's Transform.
    private Rigidbody2D rb;
    private Vector2 direction;
    private bool isInRange = false;
    private bool playerDetected = false;

    void Start()
    {
        explosionAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Tag your player GameObject as "Player". 
    }
    void Update()
    {
        if (isInRange == false)
        {
            isInRange = Physics2D.OverlapCircle(transform.position, detectionRadius, whatIsPlayer);
            direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }

        if (isInRange == true && playerDetected == false)
        {
            rb.velocity = Vector2.zero;
            playerDetected = true;
            Explode();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // DO DAMAGE TO PLAYER
        }
    }

    void Explode()
    {
        explosionAnim.SetTrigger("Exploding");

        Destroy(gameObject, deathTimer);
    }
}
