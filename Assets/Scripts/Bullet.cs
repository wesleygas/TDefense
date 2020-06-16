using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    public Rigidbody2D rb;
    public float speed = 1.0f;

    void Update()
    {
        if (target == null) return;
        Vector3 look = target.transform.position - transform.position;
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        rb.AddForce(transform.up * Time.deltaTime * speed, ForceMode2D.Impulse);
    }
}