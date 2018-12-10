using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BookPauseMenu : MonoBehaviour {

    //public bool isPaused;
    public bool settingsOn;
    //GameObject Menu;
    GameObject SettingsMenu;

    CanvasAssigner canvasAssigner;
    GameObject Canvas;

    //Button continueButton;
    Button settingsButton;
    //Button exitButton;
    Button exitButton1;
    Button gearButton;
    Button exitFromPage;

    private void Awake()
    {
        Canvas = GameObject.Find("Canvas");
        canvasAssigner = Canvas.GetComponent<CanvasAssigner>();
    }
    // Use this for initialization
    void Start()
    {
        

        gearButton = GameObject.Find("Settings Icon").GetComponent<Button>();
        exitFromPage = GameObject.Find("Exit Icon").GetComponent<Button>();

        //continueButton = canvasAssigner.Continue;
        //settingsButton = canvasAssigner.Settings;
        //exitButton = canvasAssigner.Exit;
        exitButton1 = canvasAssigner.Exit1;

        //Menu = canvasAssigner.PauseMenu;
        SettingsMenu = canvasAssigner.SettingsMenu;

        
    }

    // Update is called once per frame
    void Update()
    {
        //continueButton.onClick.AddListener(Continue);
        //settingsButton.onClick.AddListener(Settings);
        //exitButton.onClick.AddListener(Exit);
        exitButton1.onClick.AddListener(Exit);
        gearButton.onClick.AddListener(Settings);
        exitFromPage.onClick.AddListener(Gtfo);

        //if (isPaused == true)
        //{
        //    Menu.SetActive(true);
        //    Time.timeScale = 0f;
        //}

        //if (isPaused == false)
        //{
        //    Menu.SetActive(false);
        //    if (settingsOn == false)
        //    {
        //        Time.timeScale = 1f;
        //    }
        //}

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
        //isPaused = false;
        settingsOn = false;
    }

    public void Settings()
    {
        //isPaused = false;
        settingsOn = true;
    }

    public void Exit()
    {
        if (settingsOn == true)
        {
            settingsOn = false;
        }
        //if (isPaused == true)
        //{
        //    isPaused = false;
        //}
    }

    public void Gtfo()
    {
        Application.Quit();
    }
}
