using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControls : MonoBehaviour {

    public float rotSpeed;
	
	void Start ()
    {
        Input.gyro.enabled = true;
        var x = Input.gyro.rotationRateUnbiased.x;
        var y = Input.gyro.rotationRateUnbiased.y;

    }

    void Update()
    {
        
        this.transform.Rotate(-Input.gyro.rotationRateUnbiased.x * rotSpeed, -Input.gyro.rotationRateUnbiased.y*rotSpeed, 0);
    }
}
