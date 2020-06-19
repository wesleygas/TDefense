using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CurrencyManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int moneyPerSecond = 10;
    public float energyPerSecond = 1.5f;
    public int maxEnergy = 20;
    float energyAmount = 0;
    int moneyAmount = 100;
    TextMeshProUGUI moneyText, maxEnergyText, energyText;
    AudioManager audioManager;
    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        moneyText = GameObject.Find("Money").GetComponentInChildren<TextMeshProUGUI>();
        maxEnergyText = GameObject.Find("Energy/MaxEnergy").GetComponent<TextMeshProUGUI>();
        energyText = GameObject.Find("Energy/CurrEnergy").GetComponent<TextMeshProUGUI>();
        moneyText.text = moneyAmount.ToString();
        energyText.text = energyAmount.ToString("F0");
        maxEnergyText.text = "/ " + maxEnergy.ToString();
        InvokeRepeating("UpdateStats", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateStats() {
        moneyAmount+=moneyPerSecond;
        moneyText.text = moneyAmount.ToString();
        energyAmount+= energyPerSecond;
        if(energyAmount > maxEnergy){
            energyAmount = maxEnergy;
        }
        energyText.text = energyAmount.ToString("F0");
    }

    public bool buyTower(int price){
        if(price <= moneyAmount){
            moneyAmount -= price;
            moneyText.text = moneyAmount.ToString();
            return true;
        }else{
            audioManager.Play("nocash");
            return false;
        }
    } 

    public void useEnergy(int amount){

    }
}
