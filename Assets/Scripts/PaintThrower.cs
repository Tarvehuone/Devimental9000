using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintThrower : MonoBehaviour
{
    public GameObject paintBallPrefab;
    public Transform firePoint;
    public float firePower = 5f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0.0f;
    public AudioSource paintThrowerAudio;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextFireTime)
        {
            if (!paintThrowerAudio.isPlaying)
                paintThrowerAudio.Play();
            GameObject newPaintBall = Instantiate(paintBallPrefab, firePoint.position, firePoint.rotation);

            float randomSize = Random.Range(0.25f, 0.75f);
            newPaintBall.transform.localScale = new Vector3(randomSize, randomSize, randomSize);

            Rigidbody2D paintBallRB = newPaintBall.GetComponent<Rigidbody2D>();
            paintBallRB.AddForce(firePoint.right * firePower, ForceMode2D.Impulse);
            paintBallRB.AddForce(firePoint.up * Random.Range(-3f, 3f), ForceMode2D.Impulse);

            Destroy(newPaintBall, 0.5f);

            nextFireTime = Time.time + fireRate;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            paintThrowerAudio.Stop();
        }
    }
}
