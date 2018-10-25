using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    float gameTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameTime += Time.deltaTime;
        //Debug.Log(Mathf.RoundToInt(gameTime));
	}
}
