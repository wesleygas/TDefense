using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyFLy : MonoBehaviour
{
    private Animator animator;
    private Transform target;

    public int lifes = 100;
    public int coins = 100;
    public int damage = 1;
    public int speed = 10;


    void Start()
    {
        animator = GetComponent<Animator>();

        target = GameObject.Find("target").transform;
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
        if (target.position.y <= transform.position.y)
        {
            GameState.habitants -= damage;
            Destroy(gameObject);
        }

        transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        GameState.coins += coins;
        Destroy(gameObject);
    }
}