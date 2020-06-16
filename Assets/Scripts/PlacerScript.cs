using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacerScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool placed = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(!placed){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            Vector3 newPosition = new Vector3();
            newPosition.z = 0;
            newPosition.x = Mathf.Round(mousePos.x-.5f)+.5f;
            newPosition.y = Mathf.Round(mousePos.y+.5f)-.5f;
            gameObject.transform.position = newPosition;
            if(mousePos.x < 6f && Input.GetMouseButtonDown(0)){
                OnMouseDown();
            }
        }
        
    }

    private void OnMouseDown(){
        if(Maps.IsGround((int)(gameObject.transform.position.x), (int)(gameObject.transform.position.y))){
            placed = true;
            GameObject.Find("UIController").GetComponent<TowerSpawner>().SendMessage("WasPlaced");
        }
        
    }
}
