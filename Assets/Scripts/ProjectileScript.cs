using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject target;
    public float speed = 1.0f;
    public int damage = 1;
    public bool isVertical;
    private Rigidbody2D rb;

    float angle;
    AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if(audioManager) audioManager.Play("shoot");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (target == null) return;
        Vector3 look = target.transform.position - transform.position;


        if (look.magnitude < 0.2f)
        {
            target.SendMessage("Damage", damage);
            Destroy(gameObject);
        }
        if(isVertical){
            angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            rb.AddForce(transform.up * Time.deltaTime * speed, ForceMode2D.Impulse);
        }else{
            angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            rb.AddForce(transform.right * Time.deltaTime * speed, ForceMode2D.Impulse);
        }
    }
}