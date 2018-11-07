using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BookPauseMenu : MonoBehaviour {

    public bool isPaused;
    public bool settingsOn;
    public GameObject Menu;
    public GameObject SettingsMenu;

    public Button continueButton;
    public Button settingsButton;
    public Button exitButton;
    public Button exitButton1;
    public Button gearButton;
    public Button exitFromPage;

    // Use this for initialization
    void Start()
    {
        Button btn1 = gearButton.GetComponent<Button>();
        Button btn2 = exitFromPage.GetComponent<Button>();
        btn1.onClick.AddListener(Settings);
        btn2.onClick.AddListener(Gtfo);
    }

    // Update is called once per frame
    void Update()
    {

        continueButton.onClick.AddListener(Continue);
        settingsButton.onClick.AddListener(Settings);
        exitButton.onClick.AddListener(Exit);
        exitButton1.onClick.AddListener(Exit);

        if (isPaused == true)
        {
            Menu.SetActive(true);
            Time.timeScale = 0f;
        }

        if (isPaused == false)
        {
            Menu.SetActive(false);
            if (settingsOn == false)
            {
                Time.timeScale = 1f;
            }
        }

        if (settingsOn == true)
        {
            SettingsMenu.SetActive(true);
        }

        if (settingsOn == false)
        {
            SettingsMenu.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (settingsOn == true)
            {
                settingsOn = false;
            }
        }
    }
    void Continue()
    {
        isPaused = false;
        settingsOn = false;
    }

    void Settings()
    {
        isPaused = false;
        settingsOn = true;
    }

    void Exit()
    {
        if (settingsOn == true)
        {
            settingsOn = false;
        }
        if (isPaused == true)
        {
            isPaused = false;
        }
    }

    void Gtfo()
    {
        Application.Quit();
    }
}
