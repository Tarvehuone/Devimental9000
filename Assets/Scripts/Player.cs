using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public Transform playerGraphics;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the player
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");

        AnimatePlayer();

        if (movementDirection.x < 0)
        {
            playerGraphics.localScale = new Vector3(-1, 1, 1);
        }
        else if (movementDirection.x > 0)
        {
            playerGraphics.localScale = new Vector3(1, 1, 1);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementDirection.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private void AnimatePlayer()
    {
        if (movementDirection.y > 0)
        {
            anim.SetBool("IsWalkingUp", true);
            anim.SetBool("IsWalking", false);
        }
        else if (movementDirection.y < 0)
        {
            anim.SetBool("IsWalkingUp", false);
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalkingUp", false);
        }

        if (movementDirection.x != 0 && movementDirection.y <= 0 || movementDirection.y < 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }
}