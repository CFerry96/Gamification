using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleLight : MonoBehaviour {
    private bool lit = false;
    private Light solas;

	// Use this for initialization
	void Start () {
        solas = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if(lit == true)
        {
            solas.enabled = true;
        }
        else if(lit == false)
        {
            solas.enabled = false;
        }
	}

    private void OnMouseDown()
    {
        if(lit == false)
        {
            lit = true;
        }
        else if(lit == true)
        {
            lit = false;
        }
    }
}
