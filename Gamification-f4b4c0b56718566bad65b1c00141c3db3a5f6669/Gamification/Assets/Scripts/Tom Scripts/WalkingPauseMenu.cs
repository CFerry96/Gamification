using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalkingPauseMenu : MonoBehaviour {

    public bool Pause;
    public bool settingsOn;
    public GameObject Menu;
    public GameObject MovementButtons;
    public GameObject SettingsMenu;

    public Button continueButton;
    public Button settingsButton;
    public Button exitButton;
    public Button exitButton1;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        continueButton.onClick.AddListener(Continue);
        settingsButton.onClick.AddListener(Settings);
        exitButton.onClick.AddListener(Exit);
        exitButton1.onClick.AddListener(Exit);


        if (Pause == true)
        {
            Menu.SetActive(true);
            MovementButtons.SetActive(false);
            Time.timeScale = 0f;
        }

        if (Pause == false)
        {
            Menu.SetActive(false);
            if (settingsOn == false)
            {
                Time.timeScale = 1f;
                MovementButtons.SetActive(true);
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
            Pause = !Pause;
            if (settingsOn == true)
            {
                settingsOn = false;
            }
        }
	}
    void Continue ()
    {
        Pause = false;
    }

    void Settings()
    {
        Pause = false;
        settingsOn = true;
    }

    void Exit()
    {
        if (settingsOn == true)
        {
            settingsOn = false;
        }
        if (Pause == true)
        {
            Pause = false;
        }
    }
}
