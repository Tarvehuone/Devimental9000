using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingHP : MonoBehaviour
{
    public int maxHealth = 150; // Maximum health of the painting
    private int currentHealth;   // Current health of the painting

    void Start()
    {
        currentHealth = maxHealth; // Initialize the current health to the maximum health
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any update logic you need here
    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Paint")
        {
            currentHealth -= 5;
            Debug.Log("Painting health: " + currentHealth);
            PaintingDeath();
        }
    }

    void PaintingDeath()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}