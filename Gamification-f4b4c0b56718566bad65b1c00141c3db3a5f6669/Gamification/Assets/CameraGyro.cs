using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGyro : MonoBehaviour {

    GameObject camParent;

	// Use this for initialization
	void Start () {
        camParent = GameObject.Find("player");
        camParent.transform.position = this.transform.position;
        Input.gyro.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        
        camParent.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y * 1.7f, 0);
        this.transform.Rotate(-Input.gyro.rotationRateUnbiased.x * 1.7f, 0, 0);
	}
}
