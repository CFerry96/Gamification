using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BookPauseMenu : MonoBehaviour {

    public bool settingsOn;
    public GameObject SettingsMenu, exitButton;

    // Update is called once per frame
    void Update()
    {
        //gearButton.onClick.AddListener(Settings);

        if (settingsOn == true)
        {
            Time.timeScale = 0f;
            SettingsMenu.SetActive(true);
        }

        if (settingsOn == false)
        {
            Time.timeScale = 1f;
            SettingsMenu.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsOn = !settingsOn;
        }
    }
    public void Continue()
    {
        settingsOn = false;
    }

    public void Settings()
    {
        if (settingsOn == false)
        {
            exitButton.SetActive(true);
        }
        if (settingsOn == true)
        {
            exitButton.SetActive(false);
        }
        settingsOn = !settingsOn;
    }

    public void Exit()
    {
        if (settingsOn == true)
        {
            settingsOn = false;
            exitButton.SetActive(false);
        }
    }

    public void Gtfo()
    {
        Application.Quit();
    }
}
