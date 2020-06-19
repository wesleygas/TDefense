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
        InvokeRepeating("UpdateStats", 1f, 1f);

    }

    void UpdateStats()
    {
        var children = new List<GameObject>();
        foreach (Transform child in enemySummary.transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));

        GameObject tmp;
        (List<int> counts, List<Sprite> sprites) = phase.GetComponent<Phase>().Summary();

        for (int i = 0; i < counts.Count && i < 4; i++)
        {
            tmp = Instantiate(enemyEntry, Vector3.zero, Quaternion.identity);
            tmp.transform.SetParent(enemySummary.transform);
            RectTransform rt = tmp.GetComponent<RectTransform>();
            rt.offsetMin = new Vector2(-0.3f, -i * 0.7f + 0.5f);
            rt.offsetMax = new Vector2(-0.3f, -i * 0.7f + 0.5f);
            Image image = tmp.transform.GetChild(0).GetComponent<Image>();
            TextMeshProUGUI text = tmp.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            text.text = counts[i].ToString();
            image.sprite = sprites[i];

        }
    }

    // Update is called once per frame
    // void Update()
    // {

    // }
}