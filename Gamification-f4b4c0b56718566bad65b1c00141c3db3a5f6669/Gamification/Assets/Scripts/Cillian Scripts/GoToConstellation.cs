using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToConstellation : MonoBehaviour {

    public GameObject Camera;
    public ZoomToSpace lc;

    void OnMouseDown()
    {
        lc = Camera.GetComponent<ZoomToSpace>();
        lc.enabled = true;

    }
}
