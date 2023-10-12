using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    private AudioSource deathAudio;
    public AudioSource hurtAudio;
    public int hitpoints = 1000;
    public GameObject paintBucketPrefab;
    public GameObject gasCanisterPrefab;

    void OnEnable()
    {
        deathAudio = GameObject.FindWithTag("DeathAudio").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Flame")
        {
            if (!hurtAudio.isPlaying)
                hurtAudio.Play();
            hitpoints -= 5;
            Debug.Log("Enemy health: " + hitpoints);
            EnemyDeath();
        }
    }

    void EnemyDeath()
    {
        if (hitpoints <= 0)
        {
            deathAudio.Play();

            float randomChance = Random.Range(0f, 1f);

            // Implement the 5% chance to drop a paint bucket
            if (randomChance <= 0.05f)
            {
                Instantiate(paintBucketPrefab, transform.position, Quaternion.identity);
            }
            else if (randomChance >= 0.9f)
            {
                Instantiate(gasCanisterPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
