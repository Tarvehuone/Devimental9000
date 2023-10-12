using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Napoleon : MonoBehaviour
{
    public Transform firePoint;
    public float blastPower;
    public GameObject enemyBlastPrefab;
    public int circleBlastAmount = 40;
    private int blastCount = 0;
    private Animator napoAnim;
    public AudioSource blastSound;
    public AudioSource punchSound;
    private Rigidbody2D rb;
    private Transform player;
    public float moveSpeed = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        napoAnim = GetComponent<Animator>();
        StartCoroutine(RandomAttack());
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private IEnumerator RandomAttack()
    {
        yield return new WaitForSeconds(1f);

        int randomAtt = Random.Range(0, 2);

        if (randomAtt == 0)
        {
            StartCoroutine(CircleAttack());
        }
        else
        {
            StartCoroutine(HusAttack());
        }
        Debug.Log("random attack: " + randomAtt);
    }

    private IEnumerator CircleAttack()
    {
        napoAnim.SetTrigger("CircleAttack");

        yield return new WaitForSeconds(0.75f);

        if (!blastSound.isPlaying)
            blastSound.Play();

        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            BlastTimer();
            blastCount++;

            if (blastCount == circleBlastAmount)
            {
                blastCount = 0;
                break;
            }
        }
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(RandomAttack());
    }
    // private IEnumerator WaveAttack()
    // {
    //     napoAnim.SetTrigger("WaveAttack");

    //     yield return new WaitForSeconds(0.75f);


    //     while (true)
    //     {
    //         yield return new WaitForSeconds(0.01f);
    //         BlastTimer();
    //         blastCount++;

    //         if (blastCount == circleBlastAmount)
    //         {
    //             blastCount = 0;
    //             break;
    //         }
    //     }
    //     yield return new WaitForSeconds(0.5f);

    //     while (true)
    //     {
    //         yield return new WaitForSeconds(0.01f);
    //         BlastTimer();
    //         blastCount++;

    //         if (blastCount == circleBlastAmount)
    //         {
    //             blastCount = 0;
    //             break;
    //         }
    //     }
    //     yield return new WaitForSeconds(1f);

    //     StartCoroutine(RandomAttack());
    // }

    private IEnumerator HusAttack()
    {
        napoAnim.SetTrigger("HusAttack");

        if (!punchSound.isPlaying)
            punchSound.Play();

        yield return new WaitForSeconds(1f);

        StartCoroutine(RandomAttack());
    }

    private void BlastTimer()
    {
        GameObject newBlast = Instantiate(enemyBlastPrefab, firePoint.position, firePoint.rotation);
        newBlast.GetComponent<Rigidbody2D>().AddForce(firePoint.right * -blastPower, ForceMode2D.Impulse);
        newBlast.transform.localScale = new Vector3(-3, 3, 3);
    }
}