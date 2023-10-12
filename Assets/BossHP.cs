using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHP : MonoBehaviour
{
    private AudioSource deathAudio;
    public AudioSource hurtAudio;
    public int hitpoints = 1000;
    void Start()
    {
        deathAudio = GameObject.FindWithTag("NapoleonDeath").GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Flame")
        {
            if (!hurtAudio.isPlaying)
                hurtAudio.Play();

            hitpoints -= 5;
            Debug.Log("Boss health: " + hitpoints);
            EnemyDeath();
        }
    }

    void EnemyDeath()
    {
        if (hitpoints <= 0)
        {
            deathAudio.Play();
            Invoke("EnemyDeathTimer", 2f);
            Destroy(gameObject);
        }
    }

    void EnemyDeathTimer()
    {
        SceneManager.LoadScene("FinalScene");
    }
}
