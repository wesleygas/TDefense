using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    private Rigidbody2D rb;
    public float speed = 1.0f;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (target == null) return;
        Vector3 look = target.transform.position - transform.position;


        if (look.magnitude < 0.2f)
        {
            Destroy(gameObject);
        }
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        rb.AddForce(transform.up * Time.deltaTime * speed, ForceMode2D.Impulse);
    }

}