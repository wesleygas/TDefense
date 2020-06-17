using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase : MonoBehaviour
{
    private int index = 0;

    void Start()
    {
        index = 0;
    }

    public int Count()
    {
        return transform.childCount;
    }
    void Next()
    {
        if (index < transform.childCount)
        {
            transform.GetChild(index).gameObject.SendMessage("Go");
            index += 1;
        }
    }

}