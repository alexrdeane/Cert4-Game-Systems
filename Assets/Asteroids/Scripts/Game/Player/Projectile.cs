using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector3 direction)
    {
        rigid.AddForce(direction * speed, ForceMode2D.Impulse);
    }
}
