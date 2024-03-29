using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private float last;
    public float delay = 5.0f;
    private int index = 0;
    private bool canGo = false;

    void Start()
    {
        index = -1;
        last = Time.time - delay;
        canGo = false;
    }

    void Go()
    {
        canGo = true;
    }

    public (List<int>, List<Sprite>) Summary()
    {

        List<int> counts = new List<int>();
        List<Sprite> sprites = new List<Sprite>();

        for (int i = index + 1; i < transform.childCount; i++)
        {
            (int count, Sprite sprite) = transform.GetChild(i).gameObject.GetComponent<WaveBlock>().Summary();
            counts.Add(count);
            sprites.Add(sprite);
        }

        return (counts, sprites);
    }


    public int Count()
    {
        int count = 0;

        for (int i = 0; i < transform.childCount; i++)
        {
            count += transform.GetChild(i).gameObject.transform.childCount;
        }

        return count;

    }
    void Update()
    {
        if (canGo && index < (transform.childCount - 1) && (Time.time - last > delay))
        {
            index += 1;
            last = Time.time;
            transform.GetChild(index).gameObject.SendMessage("Go");
        }
    }

}