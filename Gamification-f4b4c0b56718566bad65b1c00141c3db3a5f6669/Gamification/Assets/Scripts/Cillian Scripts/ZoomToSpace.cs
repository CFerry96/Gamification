using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomToSpace : MonoBehaviour {

    public GameObject zoomLocation, buttons;
    public float blackoutTime;

    // Update is called once per frame
    void Update () {

        transform.position = Vector3.Lerp(transform.position, zoomLocation.transform.position, Time.deltaTime * blackoutTime);
        //transform.LookAt(lerpingTarget.transform.parent);
        buttons.SetActive(false);
    }
}
