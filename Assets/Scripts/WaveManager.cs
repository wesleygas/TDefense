using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WaveManager : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject enemySummary, phase;
    public GameObject enemyEntry;
    void Start()
    {
        enemySummary = GameObject.Find("EnemySummary");
        phase = GameObject.Find("phase");

        GameObject tmp;
        (List<int> counts, List<Sprite> sprites) = phase.GetComponent<Phase>().Summary();

        if (counts.Capacity > 0)
        {

            tmp = Instantiate(enemyEntry, enemySummary.transform.position, Quaternion.identity);
            tmp.transform.SetParent(enemySummary.transform);
            Image image = tmp.transform.GetChild(0).GetComponent<Image>();
            TextMeshProUGUI text = tmp.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            text.text = "5";
            image.sprite = sprites[0];

        }
    }

    // Update is called once per frame
    // void Update()
    // {

    // }
}