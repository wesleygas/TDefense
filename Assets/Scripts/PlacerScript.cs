using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacerScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool placed = false;
    public int price = 100;
    GameObject uiController;
    public GameObject rangeFB;
    CurrencyManager currencyManager;
    AudioManager audioManager;
    
    void Start()
    {
        float radius = gameObject.GetComponent<Tower>().radius;
        rangeFB.transform.localScale = new Vector3(radius,radius,1)/gameObject.transform.localScale.x;
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
        }else if(transform.position.x < 6.7f){
            if(audioManager) audioManager.Play("cant");
        }
        
    }

    void OnMouseOver()
    {
        Color color;
        SpriteRenderer sr = rangeFB.GetComponent<SpriteRenderer>();
        sr.enabled = true;
        //If your mouse hovers over the GameObject with the script attached, output this message
        if(!placed){
            if(Maps.IsGround((int)(gameObject.transform.position.x + .5f), (int)(gameObject.transform.position.y-.5f))){
                color = new Color(0f,1f,0f, .3f);
            }else{
                color = new Color(1f,0f,0f, .3f);
            }
        }else{
            color = new Color(1f,1f,1f,.3f);            
        }
        sr.color = color;
    }

    void OnMouseExit()
    {
        SpriteRenderer sr = rangeFB.GetComponent<SpriteRenderer>();
        if(placed){
          sr.enabled = false;  
        }
    }


}
