using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int hitpointsMax = 100;
    public int hitpoints;
    // Start is called before the first frame update
    void Start()
    {
        hitpoints = hitpointsMax;
        FindObjectOfType<Healthbar>().SetMaxHealth(hitpoints);
    }

    // Update is called once per frame 
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collider)
    {
    }

    void PlayerDeath()
    {
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "PaintBucket")
        {
            EatPaint();
            FindObjectOfType<Healthbar>().SetHealth(hitpoints);
        }
        if (collider.gameObject.tag == "Enemy")
        {
            FindObjectOfType<Healthbar>().SetHealth(hitpoints);
            hitpoints -= 5;
            Debug.Log("Player health: " + hitpoints);
            PlayerDeath();
        }
    }
    public void EatPaint()
    {
        if (hitpoints < hitpointsMax)
        {
            hitpoints += 10;
            if (hitpoints > hitpointsMax)
            {
                hitpoints = hitpointsMax;
            }
        }
    }

}