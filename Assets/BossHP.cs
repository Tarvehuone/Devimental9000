using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHP : MonoBehaviour
{
    private AudioSource deathAudio;
    public AudioSource hurtAudio;
    public int hitpoints = 1000;
    private BossHPBar hpBar;
    void Start()
    {
        hpBar = FindObjectOfType<BossHPBar>();
        deathAudio = GameObject.FindWithTag("NapoleonDeath").GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Flame")
        {
            if (!hurtAudio.isPlaying)
                hurtAudio.Play();

            hitpoints -= 5;
            hpBar.UpdateHP(hitpoints);
            Debug.Log("Boss health: " + hitpoints);
            EnemyDeath();
        }
    }

    void EnemyDeath()
    {
        if (hitpoints <= 0)
        {
            if (!deathAudio.isPlaying)
                deathAudio.Play();
            Invoke("EnemyDeathTimer", 4f);
            Destroy(gameObject, 4f);
        }
    }

    void EnemyDeathTimer()
    {
        SceneManager.LoadScene("FinalScene");
    }
}
