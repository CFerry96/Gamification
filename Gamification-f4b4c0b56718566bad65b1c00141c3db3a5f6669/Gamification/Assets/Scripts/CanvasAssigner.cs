using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasAssigner : MonoBehaviour {

    public GameObject SettingsMenu;
    //public Button Exit1;

	// Use this for initialization
	void Start () {
        SettingsMenu = transform.Find("SettingsMenu").gameObject;
        //Exit1 = SettingsMenu.transform.Find("Exit").gameObject.GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
