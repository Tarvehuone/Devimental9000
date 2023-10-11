using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float moveSpeed = 3f; // Adjust the movement speed as needed.
    public float detectionRange = 5f; // The range at which the enemy detects the player.
    public Transform ghostGraphics;
    public Animator ghostAnim;
    public GameObject enemyBlast;
    public float blastSpeed = 1;
    public float blastRate = 2f;
    private float nextBlastTime = 0.0f;


    private Transform player;
    private Rigidbody2D rb;
    private Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;

            Vector2 blastDirection = player.position - transform.position;
            blastDirection.Normalize();
            float angle = Mathf.Atan2(blastDirection.y, blastDirection.x) * Mathf.Rad2Deg;

            if (Vector2.Distance(transform.position, player.position) <= detectionRange && Time.time >= nextBlastTime)
            {
                GameObject newBlast = Instantiate(enemyBlast, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
                newBlast.GetComponent<Rigidbody2D>().velocity = blastDirection * blastSpeed;

                nextBlastTime = Time.time + blastRate;
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
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
