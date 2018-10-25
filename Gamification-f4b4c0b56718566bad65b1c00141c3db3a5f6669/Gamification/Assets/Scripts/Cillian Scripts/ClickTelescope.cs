using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTelescope : MonoBehaviour {

    public GameObject Camera;
    public ZoomToTelscope lc;

    void OnMouseDown()
    {
        lc = Camera.GetComponent<ZoomToTelscope>();
        lc.enabled = true;

    }
}
