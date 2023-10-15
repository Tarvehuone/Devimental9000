using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject doors;
    public GameObject paintings;
    public AudioSource doorCloseSound;

    void Awake()
    {
        paintings.SetActive(false);
        doors.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            doorCloseSound.Play();
            doors.SetActive(true);
            paintings.SetActive(true);
        }
    }
}
