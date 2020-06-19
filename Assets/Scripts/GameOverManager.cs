using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update

    private TextMeshProUGUI gameOverStatus;
    void Start()
    {
        gameOverStatus = GameObject.Find("GameOver/Text").GetComponent<TextMeshProUGUI>();
        InvokeRepeating("UpdateStats", 1f, 1f);
    }

    void UpdateStats()
    {

        if (GameState.habitants > 0)
        {
            gameOverStatus.text = "YOU WON!";
        }
        else
        {
            gameOverStatus.text = "YOU LOST!";

        }

    }

}
