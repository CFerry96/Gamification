using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnRed : MonoBehaviour {
    public Material materialColour;

	// Use this for initialization
	void Start () {
		materialColour = GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void clicked()
    {
        materialColour.color = Color.red;
        Debug.Log("Redboy");
    }
}
