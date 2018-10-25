using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public Image Black;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var tempVariable = Black.color;
        tempVariable.a -= Time.deltaTime / 2.5f;
        Black.color = tempVariable;

	}
}
