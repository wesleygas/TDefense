using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBlock : MonoBehaviour
{
    public void Go()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SendMessage("Go");
        }

    }
}