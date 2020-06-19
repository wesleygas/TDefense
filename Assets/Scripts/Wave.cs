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
        index = 0;
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

        for (int i = index; i < transform.childCount; i++)
        {
            (int count, Sprite sprite) = transform.GetChild(index).gameObject.GetComponent<WaveBlock>().Summary();
            counts.Add(count);
            sprites.Add(sprite);
        }

        return (counts, sprites);
    }

    void Update()
    {
        if (canGo && index < transform.childCount && (Time.time - last > delay))
        {
            last = Time.time;
            transform.GetChild(index).gameObject.SendMessage("Go");
            index += 1;
        }
    }

}