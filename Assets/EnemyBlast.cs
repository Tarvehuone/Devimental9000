using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlast : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyBlast", 5f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "IgnoreCollision")
        {
            Destroy(this.gameObject);
        }
    }

    void DestroyBlast()
    {
        Destroy(this.gameObject);
    }
}
