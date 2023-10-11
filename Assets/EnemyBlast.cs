using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlast : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 10f);
    }
    void OnColliderEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
    }
}
