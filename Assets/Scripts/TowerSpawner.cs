using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    bool hasTower = false;
    public GameObject Tower;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTower(){
        if(!hasTower){
            hasTower=true;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Instantiate(Tower,mousePos,Quaternion.identity);
        }
        /*else{
            //Troca a torre na mão
        }
        */
    }
}
