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

    void PlayerDeath()
    {
        if (hitpoints <= 0)
        {
            GameObject.FindWithTag("Fail").GetComponent<FailManager>().DeathScreen();
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
            hitpoints -= 5;
            FindObjectOfType<Healthbar>().SetHealth(hitpoints);
            Debug.Log("Player health: " + hitpoints);
            PlayerDeath();
        }
        else if (collider.gameObject.tag == "Boss")
        {
            hitpoints -= 20;
            FindObjectOfType<Healthbar>().SetHealth(hitpoints);
            PlayerDeath();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBlast")
        {
            hitpoints -= 5;
            FindObjectOfType<Healthbar>().SetHealth(hitpoints);
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