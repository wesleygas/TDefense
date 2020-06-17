using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : MonoBehaviour
{
    // Start is called before the first frame update
    private float last;
    public float delay = 5.0f;
    public float radius = 3.0f;

    public int LaserDamage = 10;
    Transform headTransform;
    LineRenderer lineRenderer;

    Animator animator;
    bool placed = false;
    void Start()
    {
        headTransform = transform.GetChild(0);
        last = Time.time;
        animator = gameObject.GetComponentInChildren<Animator>();
        lineRenderer = gameObject.GetComponentInChildren<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      if(!placed) return;
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
                animator.SetTrigger("Fire");
                StartCoroutine("Shoot", closest);
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, closest.transform.position);

            }
        }
    }

    public void SetPlaced(bool placed){
        this.placed = placed;
    }

    IEnumerable Shoot(GameObject closest){
        yield return new WaitForSeconds(.2f);
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(.1f);
        closest.GetComponent<Enemy>().Damage(LaserDamage);
        lineRenderer.enabled = false;
    }
}
