using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
public class StartButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool hasStarted = false;
    bool isFF = false;
    public float ff_scale = 3f;
    TextMeshProUGUI startText;
    
    void Start()
    {
        startText = gameObject.GetComponent<TextMeshProUGUI>();
    }
    public void StartToggleFF(){
        Debug.Log("Sent Message");
        if(hasStarted){
            if(isFF){
                startText.text = "ENABLE FF";
                Time.timeScale = 1f;
            }else{
                startText.text = " >> FF >>";
                Time.timeScale = ff_scale;
            }
            isFF = !isFF;
        }else{
            hasStarted = true;
            startText.text = "ENABLE FF";
        }
    }
    
}
