using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BookPauseMenu : MonoBehaviour {

    public bool settingsOn;
    public GameObject SettingsMenu;

    public Button gearButton;
    Button exitFromPage;

    // Use this for initialization
    void Start()
    {
        gearButton = GameObject.Find("Settings Icon").GetComponent<Button>();
    }

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
        settingsOn = !settingsOn;
    }

    public void Exit()
    {
        if (settingsOn == true)
        {
            settingsOn = false;
        }
    }

    public void Gtfo()
    {
        Application.Quit();
    }
}
