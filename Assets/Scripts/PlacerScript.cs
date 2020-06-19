﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacerScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool placed = false;
    public int price = 100;
    GameObject uiController;
    CurrencyManager currencyManager;
    AudioManager audioManager;
    void Start()
    {
        uiController = GameObject.Find("UIController");
        currencyManager = uiController.GetComponent<CurrencyManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(!placed){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            Vector3 newPosition = new Vector3();
            newPosition.z = 0;
            newPosition.x = Mathf.Round(mousePos.x-.5f) + .5f;
            newPosition.y = Mathf.Round(mousePos.y+.5f) - .5f;
            gameObject.transform.position = newPosition;
            if(mousePos.x < 6f && Input.GetMouseButtonDown(0)){
                OnMouseDown();
            }
        }
        
    }

    private void OnMouseDown(){
        if(Maps.IsGround((int)(gameObject.transform.position.x + .5f), (int)(gameObject.transform.position.y-.5f))){
            if(currencyManager.buyTower(price)){
                placed = true;
                if(audioManager) audioManager.Play("place");
                gameObject.GetComponent<Tower>().SetPlaced(true);
                uiController.GetComponent<TowerSpawner>().SendMessage("WasPlaced");
            }
            
        }
        
    }
}
