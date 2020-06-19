using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase : MonoBehaviour
{
    private int index;

    void Start()
    {
        index = -1;
    }


    public (List<int>, List<Sprite>) Summary()
    {
        int local = index;
        if (local < 0)
        {
            local = 0;
        }

        bool enemies = RemainderEnemies();

        if (enemies)
        {
            return transform.GetChild(local).gameObject.GetComponent<Wave>().Summary();
        }
        else
        {
            return transform.GetChild(local + 1).gameObject.GetComponent<Wave>().Summary();
        }
    }
    public bool RemainderWaves()
    {

        return (transform.childCount - (index + 1)) > 0;
    }


    public bool RemainderEnemies()
    {

        int local = index;

        if (local < 0)
        {
            local = 0;
        }

        int count = transform.GetChild(local).gameObject.GetComponent<Wave>().Count();
        return count > 0;
    }
    public void Go()
    {


        if (index < transform.childCount)
        {
            index += 1;
        }

        transform.GetChild(index).gameObject.SendMessage("Go");

    }

}