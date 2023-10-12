using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator bodyAnim;
    public Animator feetAnim;
    public Transform playerGraphics;
    public float moveSpeed = 5f;
    public Transform rotatingObject;
    public GameObject paintThrower;
    public GameObject flameThrower;
    public AudioSource walkingAudio;


    // PRIVATES
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

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            flameThrower.SetActive(!flameThrower.activeSelf);
            paintThrower.SetActive(!paintThrower.activeSelf);
        }

        if (movementDirection.x != 0 && bodyAnim.GetBool("IsWalkingDown") == false)
        {
            if (!walkingAudio.isPlaying)
                walkingAudio.Play();
            feetAnim.SetBool("IsRunning", true);
        }
        else
        {
            feetAnim.SetBool("IsRunning", false);
        }

        if (movementDirection.x != 0 && feetAnim.GetBool("IsLookingDown") == true)
        {
            feetAnim.SetBool("IsRunningDown", true);
            feetAnim.SetBool("IsLookingDown", false);
        }

        if (movementDirection.x == 0 && movementDirection.y == 0)
        {
            if (walkingAudio.isPlaying)
                walkingAudio.Stop();
        }

        if (movementDirection.y != 0)
        {
            if (!walkingAudio.isPlaying)
                walkingAudio.Play();

            if (bodyAnim.GetBool("IsWalkingDown") == false)
            {
                feetAnim.SetBool("IsRunning", true);
            }
            else
            {
                feetAnim.SetBool("IsRunning", false);
            }
        }

        if (bodyAnim.GetBool("IsWalkingDown") == true || bodyAnim.GetBool("IsWalkingStraightUp") == true)
        {
            if (movementDirection.y != 0 || movementDirection.x != 0)
            {
                feetAnim.SetBool("IsRunningDown", true);
                feetAnim.SetBool("IsLookingDown", false);
            }
            else
            {
                feetAnim.SetBool("IsLookingDown", true);
                feetAnim.SetBool("IsRunningDown", false);
            }
        }
        else
        {
            feetAnim.SetBool("IsRunningDown", false);
            feetAnim.SetBool("IsLookingDown", false);
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementDirection.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private void AnimatePlayer()
    {
        if ((rotatingObject.localEulerAngles.z > 337.5 && rotatingObject.localEulerAngles.z < 360)
        || rotatingObject.localEulerAngles.z > 0 && rotatingObject.localEulerAngles.z < 22.5)
        {
            bodyAnim.SetBool("IsWalking", true);
            bodyAnim.SetBool("IsWalkingUp", false);
            bodyAnim.SetBool("IsWalkingDown", false);
            bodyAnim.SetBool("IsWalkingStraightUp", false);
            bodyAnim.SetBool("IsWalkingDownDiagonally", false);
            playerGraphics.localScale = new Vector3(1, 1, 1);
        }
        if (rotatingObject.localEulerAngles.z > 22.5 && rotatingObject.localEulerAngles.z < 67.5)
        {
            bodyAnim.SetBool("IsWalking", false);
            bodyAnim.SetBool("IsWalkingUp", true);
            bodyAnim.SetBool("IsWalkingDown", false);
            bodyAnim.SetBool("IsWalkingStraightUp", false);
            bodyAnim.SetBool("IsWalkingDownDiagonally", false);
            playerGraphics.localScale = new Vector3(1, 1, 1);
        }
        if (rotatingObject.localEulerAngles.z > 67.5 && rotatingObject.localEulerAngles.z < 112.5)
        {
            bodyAnim.SetBool("IsWalking", false);
            bodyAnim.SetBool("IsWalkingUp", false);
            bodyAnim.SetBool("IsWalkingDown", false);
            bodyAnim.SetBool("IsWalkingStraightUp", true);
            bodyAnim.SetBool("IsWalkingDownDiagonally", false);
        }
        if (rotatingObject.localEulerAngles.z > 112.5 && rotatingObject.localEulerAngles.z < 157.5)
        {
            bodyAnim.SetBool("IsWalking", false);
            bodyAnim.SetBool("IsWalkingUp", true);
            bodyAnim.SetBool("IsWalkingDown", false);
            bodyAnim.SetBool("IsWalkingStraightUp", false);
            bodyAnim.SetBool("IsWalkingDownDiagonally", false);
            playerGraphics.localScale = new Vector3(-1, 1, 1);
        }
        if (rotatingObject.localEulerAngles.z > 157.5 && rotatingObject.localEulerAngles.z < 202.5)
        {
            bodyAnim.SetBool("IsWalking", true);
            bodyAnim.SetBool("IsWalkingUp", false);
            bodyAnim.SetBool("IsWalkingDown", false);
            bodyAnim.SetBool("IsWalkingStraightUp", false);
            bodyAnim.SetBool("IsWalkingDownDiagonally", false);
            playerGraphics.localScale = new Vector3(-1, 1, 1);
        }
        if (rotatingObject.localEulerAngles.z > 202.5 && rotatingObject.localEulerAngles.z < 247.5)
        {
            bodyAnim.SetBool("IsWalking", false);
            bodyAnim.SetBool("IsWalkingUp", false);
            bodyAnim.SetBool("IsWalkingDown", false);
            bodyAnim.SetBool("IsWalkingStraightUp", false);
            bodyAnim.SetBool("IsWalkingDownDiagonally", true);
            playerGraphics.localScale = new Vector3(-1, 1, 1);
        }
        if (rotatingObject.localEulerAngles.z > 247.5 && rotatingObject.localEulerAngles.z < 292.5)
        {
            bodyAnim.SetBool("IsWalking", false);
            bodyAnim.SetBool("IsWalkingUp", false);
            bodyAnim.SetBool("IsWalkingDown", true);
            bodyAnim.SetBool("IsWalkingStraightUp", false);
            bodyAnim.SetBool("IsWalkingDownDiagonally", false);
        }
        if (rotatingObject.localEulerAngles.z > 292.5 && rotatingObject.localEulerAngles.z < 337.5)
        {
            bodyAnim.SetBool("IsWalking", false);
            bodyAnim.SetBool("IsWalkingUp", false);
            bodyAnim.SetBool("IsWalkingDown", false);
            bodyAnim.SetBool("IsWalkingStraightUp", false);
            bodyAnim.SetBool("IsWalkingDownDiagonally", true);
            playerGraphics.localScale = new Vector3(1, 1, 1);
        }
    }
}