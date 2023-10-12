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

    void Start()
    {
        napoAnim = GetComponent<Animator>();
        StartCoroutine(RandomAttack());
    }

    private IEnumerator RandomAttack()
    {
        yield return new WaitForSeconds(2f);

        int randomAtt = Random.Range(0, 3);

        if (randomAtt == 0)
        {
            StartCoroutine(CircleAttack());
        }
        else if (randomAtt == 1)
        {
            StartCoroutine(HusAttack());
        }
        else
        {
            StartCoroutine(RandomAttack());
        }
        Debug.Log("random attack: " + randomAtt);
    }

    private IEnumerator CircleAttack()
    {
        napoAnim.SetTrigger("CircleAttack");

        yield return new WaitForSeconds(0.75f);

        while (true)
        {
            yield return new WaitForSeconds(0.075f);
            BlastTimer();
            blastCount++;

            if (blastCount == circleBlastAmount)
            {
                blastCount = 0;
                break;
            }
        }
        yield return new WaitForSeconds(1f);

        StartCoroutine(RandomAttack());
    }
    private IEnumerator WaveAttack()
    {
        napoAnim.SetTrigger("WaveAttack");

        yield return new WaitForSeconds(0.75f);

        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            BlastTimer();
            blastCount++;

            if (blastCount == circleBlastAmount)
            {
                blastCount = 0;
                break;
            }
        }
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            BlastTimer();
            blastCount++;

            if (blastCount == circleBlastAmount)
            {
                blastCount = 0;
                break;
            }
        }
        yield return new WaitForSeconds(1f);

        StartCoroutine(RandomAttack());
    }

    private IEnumerator HusAttack()
    {
        napoAnim.SetTrigger("HusAttack");

        yield return new WaitForSeconds(2f);

        StartCoroutine(RandomAttack());
    }

    private void BlastTimer()
    {
        GameObject newBlast = Instantiate(enemyBlastPrefab, firePoint.position, firePoint.rotation);
        newBlast.GetComponent<Rigidbody2D>().AddForce(firePoint.right * -blastPower, ForceMode2D.Impulse);
        newBlast.transform.localScale = new Vector3(-3, 3, 3);
    }
}