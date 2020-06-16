using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;
public class TowerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    bool hasTower = false;
    GameObject currTower;
    public GameObject[] Towers;
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
        }
        else{
            Destroy(currTower);
        }
        int towerNumber = int.Parse(Regex.Match(EventSystem.current.currentSelectedGameObject.name, @"\d+").Value);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        currTower = Instantiate(Towers[towerNumber],mousePos,Quaternion.identity);
        
    }

    public void WasPlaced(){
        hasTower = false;
    }
}
