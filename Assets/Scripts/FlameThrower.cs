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
    private int ammoMax = 100;
    public int ammo;
    public float reloadTime = 2f;
    public AudioSource flameThrowerAudio;
    public AudioSource reloadAudio;
    public Transform rotatingHand;

    void Start()
    {
        ammo = ammoMax;
        FindObjectOfType<Ammobar>().SetMaxAmmo(ammo);
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (!flameThrowerAudio.isPlaying)
            {
                if (HasAmmo())
                    flameThrowerAudio.Play();
            }
            if (HasAmmo() == false)
            {
                flameThrowerAudio.Stop();
            }
        }
        else
        {
            flameThrowerAudio.Stop();
        }

        if (HasAmmo())
        {
            if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextFireTime)
            {
                GameObject newFireBall = Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation);

                float randomSize = Random.Range(0.25f, 0.75f);
                newFireBall.transform.localScale = new Vector3(randomSize, randomSize, randomSize);

                Rigidbody2D fireBallRB = newFireBall.GetComponent<Rigidbody2D>();
                fireBallRB.AddForce(firePoint.right * firePower, ForceMode2D.Impulse);
                fireBallRB.AddForce(firePoint.up * Random.Range(-3f, 3f), ForceMode2D.Impulse);

                Destroy(newFireBall, 0.5f);

                nextFireTime = Time.time + fireRate;

                ammo--;
                FindObjectOfType<Ammobar>().SetAmmo(ammo);
                Debug.Log("Ammo: " + ammo);
            }
        }
        else
        {
            if (!reloadAudio.isPlaying)
                reloadAudio.Play();

            Invoke("ReloadDelay", reloadTime);
        }

    }

    public bool HasAmmo()
    {
        return ammo > 0;
    }

    public void ReloadAmmo()
    {
        ammo = ammoMax;
        FindObjectOfType<Ammobar>().SetAmmo(ammo);
    }

    private void ReloadDelay()
    {
        ReloadAmmo();
    }
}
