using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToConstellation : MonoBehaviour {

    public GameObject cameraPos, blackScreen;
    //public GameObject buttons;
    public float blackoutTime;
    bool clicked = false;

    private void OnMouseDown()
    {
        clicked = true;
        soundManager.soundBoy.StartCoroutine("fadeInLayers");
    }

    void Update()
    {
        if (clicked == true)
        {
            cameraPos.transform.position = Vector3.Lerp(cameraPos.transform.position, transform.position, Time.deltaTime * blackoutTime);
            //buttons.SetActive(false);
            blackScreen.SetActive(true);
            
        }
    }
}

