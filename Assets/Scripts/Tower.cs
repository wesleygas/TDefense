using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private float last;
    public float delay = 5.0f;
    public float radius = 3.0f;

    public GameObject bullet;

    void Start()
    {
        last = -delay;
    }
    void Update()
    {

        if (Time.time - last < delay) return;
        last = Time.time;

        GameObject[] enemies;
        GameObject closest = null;
        var min = radius;

        enemies = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemy in enemies)
        {
            var distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < min)
            {
                closest = enemy;
            }
        }

        if (closest == null) return;

        GameObject b = Instantiate(bullet, transform.position, transform.rotation);
        b.GetComponent<Bullet>().target = closest;
    }
}