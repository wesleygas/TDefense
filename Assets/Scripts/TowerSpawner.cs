using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;
using UnityEngine.Audio;
public class TowerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    bool hasTower = false;
    GameObject currTower = null;
    int towerNumber = -1;
    public GameObject[] Towers;

    AudioManager audioManager;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
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
                if(audioManager) audioManager.Play("click");
                hasTower = true;
                towerNumber = buttonNumber;
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                currTower = Instantiate(Towers[towerNumber],mousePos,Quaternion.identity);
            }else{
                if(audioManager) audioManager.Play("placeBack");
            }
        }else{
            if(audioManager) audioManager.Play("click");
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
