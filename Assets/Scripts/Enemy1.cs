using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 3f; // Adjust the movement speed as needed.
    public float detectionRange = 5f; // The range at which the enemy detects the player.
    public Transform ghostGraphics;

    private Transform player; // Reference to the player's Transform.
    private Rigidbody2D rb;
    private Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Tag your player GameObject as "Player". 
    }

    // Update is called once per frame
    void Update()
    {

        // Check if the player is within detection range.
        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            // Move towards the player.
            detectionRange = 10f;
            direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
        else
        {
            // Stop moving when the player is out of range.
            rb.velocity = Vector2.zero;
            detectionRange = 5f;
        }

        if (direction.x < 0)
        {
            ghostGraphics.localScale = new Vector3(1, 1, 1);
        }
        else if (direction.x > 0)
        {
            ghostGraphics.localScale = new Vector3(-1, 1, 1);
        }
    }
}
