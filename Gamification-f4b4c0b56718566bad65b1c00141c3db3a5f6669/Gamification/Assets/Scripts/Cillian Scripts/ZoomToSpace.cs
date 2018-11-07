using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomToSpace : MonoBehaviour {

    public GameObject zoomLocation, buttons;
    public float blackoutTime;
    bool clicked = false;

    private void OnMouseDown()
    {
            clicked = true;
    }

    void Update () {
        if (clicked == true)
        {
            transform.position = Vector3.Lerp(transform.position, zoomLocation.transform.position, Time.deltaTime * blackoutTime);
            buttons.SetActive(false);
        }
    }
}
