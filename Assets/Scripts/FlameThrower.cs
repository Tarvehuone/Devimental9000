using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    public GameObject fireBallPrefab;
    public Transform firePoint;
    public float firePower = 5f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0.0f;
    public AudioSource flameThrowerAudio;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextFireTime)
        {
            if (!flameThrowerAudio.isPlaying)
                flameThrowerAudio.Play();
            GameObject newFireBall = Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation);

            float randomSize = Random.Range(0.25f, 0.75f);
            newFireBall.transform.localScale = new Vector3(randomSize, randomSize, randomSize);

            Rigidbody2D fireBallRB = newFireBall.GetComponent<Rigidbody2D>();
            fireBallRB.AddForce(firePoint.right * firePower, ForceMode2D.Impulse);
            fireBallRB.AddForce(firePoint.up * Random.Range(-3f, 3f), ForceMode2D.Impulse);

            Destroy(newFireBall, 0.5f);

            nextFireTime = Time.time + fireRate;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            flameThrowerAudio.Stop();
        }
    }
}
