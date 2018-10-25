using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interacting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.eulerAngles.y <= -70)
        {
            transform.Rotate(Vector3.up * Time.deltaTime);
            Debug.Log("spinny boy");
        }
        //transform.Rotate(Vector3.up * Time.deltaTime*10);
    }
}
