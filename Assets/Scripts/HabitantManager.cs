using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HabitantManager : MonoBehaviour
{
    // Start is called before the first frame update

    TextMeshProUGUI habitantsText, maxHabitantsText;
    void Start()
    {
        habitantsText = GameObject.Find("Habitants/CurrHabitants").GetComponent<TextMeshProUGUI>();
        maxHabitantsText = GameObject.Find("Habitants/MaxHabitants").GetComponent<TextMeshProUGUI>();
        maxHabitantsText.text = "/ " + GameState.maxHabitants.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        habitantsText.text = GameState.habitants.ToString();
    }
}