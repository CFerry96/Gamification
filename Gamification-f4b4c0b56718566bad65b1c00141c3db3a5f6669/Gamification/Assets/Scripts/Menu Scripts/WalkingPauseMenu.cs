using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalkingPauseMenu : MonoBehaviour {

    public bool settingsOn;
    
    public GameObject SettingsMenu, exitButton;
	
	// Update is called once per frame
	void Update () {

        if (settingsOn == true)
        {
            SettingsMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        if (settingsOn == false)
        {
            SettingsMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsOn = !settingsOn;
        }
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
