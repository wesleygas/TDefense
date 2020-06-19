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
    public AudioSource laserShot;

    public bool isLaser = false;
    public int LaserDamage = 10;
    public SpriteRenderer powerIndicator;

    Animator animator;
    LineRenderer lineRenderer;
    
    bool placed = false;
    void Start()
    {
        headTransform = transform.GetChild(0);
        last = Time.time;
        animator = gameObject.GetComponentInChildren<Animator>();
        if(isLaser) lineRenderer = gameObject.GetComponentInChildren<LineRenderer>();
    }
    void Update()
    {
        if(!placed) return;
        GameObject[] enemies;
        GameObject closest = null;

        enemies = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (enemy.transform.position.x > -14f && distance < radius)
            {
                closest = enemy;
            }
        }

        if (closest != null){
            Vector3 look = closest.transform.position - headTransform.position;
            float angle = Mathf.Atan2(look.y, look.x)* Mathf.Rad2Deg - 90f;
            headTransform.rotation = transform.rotation * Quaternion.AngleAxis(angle, Vector3.forward);
            if (Time.time - last > delay){
                last = Time.time;
                if(isLaser){
                    lineRenderer.SetPosition(0, transform.position);
                    lineRenderer.SetPosition(1, closest.transform.position);
                    GameObject target = closest; 
                    StartCoroutine("Shoot",target);
                    laserShot.Play();

                }else{
                    GameObject b = Instantiate(bullet, transform.position, transform.rotation);
                    b.GetComponent<ProjectileScript>().target = closest;
                }
                
                animator.SetTrigger("Fire");
                
            }
        }
    }

    public void SetPlaced(bool placed){
        this.placed = placed;
    }

    public void startPower(){
        StartCoroutine("powerTimer");
    }

    IEnumerator powerTimer(){
        float prevDelay = delay;
        delay /= 2;
        powerIndicator.enabled = true;
        yield return new WaitForSeconds(10);
        delay = prevDelay;
        powerIndicator.enabled = false;
    }


    IEnumerator Shoot(GameObject closest){
        yield return new WaitForSeconds(.2f);
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(.1f);
        closest.GetComponent<Enemy>().Damage(LaserDamage);
        lineRenderer.enabled = false;
    }
}