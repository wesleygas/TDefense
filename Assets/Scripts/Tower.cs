using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private float last;
    public float delay = 5.0f;
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
        GameObject closest;

        enemies = GameObject.FindGameObjectsWithTag("enemy");

        if (enemies.Length == 0) return;
        closest = enemies[0];
        var min = Vector3.Distance(transform.position, enemies[0].transform.position);
        foreach (GameObject enemy in enemies)
        {
            var distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < min)
            {
                closest = enemy;
            }
        }

        GameObject b = Instantiate(bullet, transform.position, transform.rotation);
        Debug.Log("Joguei");
        b.GetComponent<Bullet>().target = closest;

    }
}