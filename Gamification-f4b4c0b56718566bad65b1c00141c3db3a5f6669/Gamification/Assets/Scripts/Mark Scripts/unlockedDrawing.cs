using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockedDrawing : MonoBehaviour {
    public LineRenderer lr;

	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 6;
       
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < lr.positionCount; i++)
        {
            lr.SetPosition(i, persistence.control.positionArray[i]);
        }
    }
}
