using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private float last;
    public float delay = 5.0f;
    public float radius = 3.0f;

    Transform headTransform;

    public GameObject bullet;

    void Start()
    {
        headTransform = transform.GetChild(0);
        last = Time.time;
    }
    void Update()
    {

        GameObject[] enemies;
        GameObject closest = null;

        enemies = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < radius)
            {
                closest = enemy;
            }
        }

        

        if (closest != null){
            Vector3 look = closest.transform.position - headTransform.position;
            float angle = Mathf.Atan2(look.y, look.x)* Mathf.Rad2Deg - 90f;
            headTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            if (Time.time - last > delay){
                last = Time.time;
                //GameObject b = Instantiate(bullet, transform.position, transform.rotation);
                //b.GetComponent<Bullet>().target = closest;
                Debug.Log("Pey!");
            }
        }
    }
}