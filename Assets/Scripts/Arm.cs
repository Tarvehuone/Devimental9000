using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    private Transform playerTransform;
    public GameObject flamethrower;
    // Start is called before the first frame update
    void Start()
    {
        // Find the player's transform
        playerTransform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the player to the mouse
        Vector3 direction = mousePosition - playerTransform.position;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the arm to face the mouse cursor
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (transform.localEulerAngles.z > 22.5 && transform.localEulerAngles.z < 157.5)
        {
            flamethrower.GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
        else
        {
            flamethrower.GetComponent<SpriteRenderer>().sortingOrder = 5;
        }

        if (transform.localEulerAngles.z > 90 && transform.localEulerAngles.z < 270)
        {
            flamethrower.transform.localRotation = Quaternion.Euler(180, 0, 0);
        }
        else if (transform.localEulerAngles.z < 90 && transform.localEulerAngles.z > 0
        || transform.localEulerAngles.z < 360 && transform.localEulerAngles.z > 270)
        {
            flamethrower.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
