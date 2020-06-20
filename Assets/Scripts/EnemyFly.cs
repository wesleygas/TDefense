using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyFly : MonoBehaviour
{
    private Animator animator;
    private Transform target;

    public int lifes = 100;
    public int coins = 100;
    public int damage = 1;
    public int speed = 10;

    public bool move = false;



    public void Go()
    {
        move = true;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("target").transform;
        move = false;

    }

    public void Damage(int damage = 1)
    {
        lifes -= damage;
        if (lifes < 0)
        {
            animator.SetBool("dead", true);
            StartCoroutine(Die());
        }
    }

    public void Update()
    {
        if (target.position.x <= transform.position.x)
        {
            GameState.habitants -= damage;
            Destroy(gameObject);
            return;
        }

        if (move)
        {
            transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        GameState.coins += coins;
        Destroy(gameObject);
    }
}