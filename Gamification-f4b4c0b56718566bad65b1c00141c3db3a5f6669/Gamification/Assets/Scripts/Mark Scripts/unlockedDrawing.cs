﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unlockedDrawing : MonoBehaviour {
    public LineRenderer lr;
    public Text yourArt;

	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 6;
        if(persistence.control.activated == true)
        {
            yourArt.enabled = true;
        }
        else
        {
            yourArt.enabled = false;
        }
       
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < lr.positionCount; i++)
        {
            lr.SetPosition(i, persistence.control.positionArray[i]);
        }
    }
}
