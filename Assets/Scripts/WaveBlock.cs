using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBlock : MonoBehaviour
{

    public (int, Sprite) Summary()
    {
        if (transform.childCount == 0)
        {
            return (0, null);
        };

        Sprite image = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
        return (transform.childCount, image);


    }
    public void Go()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SendMessage("Go");
        }

    }
}