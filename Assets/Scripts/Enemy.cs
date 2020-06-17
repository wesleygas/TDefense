using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private AIDestinationSetter setter;

    private AIPath aIPath;
    private Transform target;

    public int lifes = 100;
    public int coins = 100;
    public int damage = 1;
    public float speed = 10;


    void Start()
    {
        animator = GetComponent<Animator>();
        setter = GetComponent<AIDestinationSetter>();
        aIPath = GetComponent<AIPath>();

        target = GameObject.Find("target").transform;
        setter.target = target;
        aIPath.maxSpeed = speed;
    }

    public void Damage(int damage = 1)
    {
        lifes -= damage;
        if (lifes < 0)
        {
            animator.SetTrigger("dead");
            StartCoroutine(Die());
        }
    }

    public void Update()
    {
        if ((target.position - transform.position).magnitude < 0.1)
        {
            GameState.habitants -= damage;
            Destroy(gameObject);
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        GameState.coins += coins;
        Destroy(gameObject);
    }
}