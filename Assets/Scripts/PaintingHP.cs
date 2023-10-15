using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingHP : MonoBehaviour
{
    public int maxHealth = 150; // Maximum health of the painting
    private int currentHealth;   // Current health of the painting
    public GameObject enemySpawnPoint;
    private bool isBroken = false;
    private Animator paintingAnim;
    void Start()
    {
        paintingAnim = GetComponent<Animator>();
        currentHealth = maxHealth; // Initialize the current health to the maximum health
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Paint")
        {
            if (currentHealth > 0)
                currentHealth -= 5;

            paintingAnim.SetFloat("Health", currentHealth);

            Debug.Log("Painting health: " + currentHealth);
            PaintingDeath();
        }
    }

    void PaintingDeath()
    {
        if (currentHealth <= 0)
        {
            if (isBroken == false)
            {
                transform.parent.parent.GetComponent<PaintingRandomizer>().CheckPaintings(true);
            }
            isBroken = true;
            Destroy(enemySpawnPoint);
        }
    }
}