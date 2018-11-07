using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LerpActivator : MonoBehaviour {

    public GameObject Camera;
    public LerpingCamera lc;

    void OnMouseDown()
    {
        lc = Camera.GetComponent<LerpingCamera>();
        lc.enabled = true;
    }
}
