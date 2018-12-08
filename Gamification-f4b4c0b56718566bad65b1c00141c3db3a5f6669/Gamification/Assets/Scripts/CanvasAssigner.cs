using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasAssigner : MonoBehaviour {

    public GameObject PauseMenu;
    public GameObject SettingsMenu;
    public Button Continue;
    public Button Settings;
    public Button Exit;
    public Button Exit1;

	// Use this for initialization
	void Start () {
        PauseMenu = transform.Find("PauseMenu").gameObject;
        SettingsMenu = transform.Find("SettingsMenu").gameObject;
        Continue = PauseMenu.transform.Find("Continue").gameObject.GetComponent<Button>();
        Settings = PauseMenu.transform.Find("Settings").gameObject.GetComponent<Button>();
        Exit = PauseMenu.transform.Find("Exit").gameObject.GetComponent<Button>();
        Exit1 = SettingsMenu.transform.Find("Exit").gameObject.GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
