using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool placed = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetMouseButtonDown(0)){
            OnMouseDown();
        }
        
        if(!placed){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            gameObject.transform.position = mousePos;
        }
        
    }

    private void OnMouseDown(){
        placed = true;
    }
}
