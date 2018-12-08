using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToConstellation : MonoBehaviour {

    public GameObject blackScreen, focus;
    //public GameObject buttons;
    public float blackoutTime;
    bool clicked = false;
    GyroControls gyroControls;
    PcCameraControlls pcCameraControlls;
    GameObject cameraPos;


    private void Start()
    {
        cameraPos = GameObject.Find("Main Camera");

        gyroControls = cameraPos.GetComponent<GyroControls>();
        pcCameraControlls = cameraPos.GetComponent<PcCameraControlls>();

    }


    private void OnMouseDown()
    {
        clicked = true;
        soundManager.soundBoy.StartCoroutine("fadeInLayers");
    }

    void Update()
    {
        if (clicked == true)
        {
            cameraPos.transform.position = Vector3.Lerp(cameraPos.transform.position, focus.transform.position, Time.deltaTime * blackoutTime);
            //buttons.SetActive(false);
            blackScreen.SetActive(true);
            gyroControls.enabled = false;
            pcCameraControlls.enabled = false;
            cameraPos.transform.rotation = Quaternion.Slerp(cameraPos.transform.rotation, focus.transform.rotation, Time.deltaTime);
         
                 
        }
    }
}

