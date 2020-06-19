using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool IsPaused = false;
    public static bool hasStarted = false;
    bool isFF = false;
    public float ff_scale = 3f;
    float currTimeScale;
    public GameObject pauseMenu;

    private GameObject phase;

    public GameObject startButton;
    public GameObject gameOverMenu;
    AudioManager audioManager;

    TextMeshProUGUI startText;
    void Start()
    {
        startText = startButton.GetComponentInChildren<TextMeshProUGUI>();
        audioManager = FindObjectOfType<AudioManager>();
        phase = GameObject.Find("phase");
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }


        if (GameState.habitants == 0)
        {
            GameOver();
        }


        bool enemies = phase.GetComponent<Phase>().RemainderEnemies();
        if (!enemies)
        {
            bool Remainder = phase.GetComponent<Phase>().RemainderWaves();
            if (Remainder)
            {
                hasStarted = false;
                ResetToggleFF();
            }
            else
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        currTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        currTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = currTimeScale;
        IsPaused = false;
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void StartToggleFF()
    {
        if (hasStarted)
        {
            if (isFF)
            {
                startText.text = "ENABLE FF";
                Time.timeScale = 1f;
                if(audioManager) audioManager.Play("restoreTime");
            }
            else
            {
                startText.text = " >> FF >>";
                Time.timeScale = ff_scale;
                if(audioManager) audioManager.Play("fastTime");
            }
            isFF = !isFF;
        }
        else
        {
            phase.SendMessage("Go");
            hasStarted = true;
            startText.text = "ENABLE FF";
        }
    }

    public void ResetToggleFF()
    {
        startText.text = "START";
    }

}
