﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;
public class TowerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    bool hasTower = false;
    GameObject currTower = null;
    int towerNumber = -1;
    public GameObject[] Towers;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTower(string towerName){
        int buttonNumber = int.Parse(Regex.Match(towerName, @"\d+").Value);
        if(hasTower){
            hasTower = false;
            Destroy(currTower);
            if(towerNumber != buttonNumber){
                hasTower = true;
                towerNumber = buttonNumber;
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                currTower = Instantiate(Towers[towerNumber],mousePos,Quaternion.identity);
            }
        }else{
            hasTower = true;
            towerNumber = buttonNumber;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            currTower = Instantiate(Towers[towerNumber],mousePos,Towers[towerNumber].transform.rotation);
        }
    }

    public void WasPlaced(){
        hasTower = false;
        
    }
}
