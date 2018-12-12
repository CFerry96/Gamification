using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour {

    public Camera cam;
    public GameObject book;

	void Update () {
        
	}

    private void OnMouseDown()
    {
        cam.transform.rotation = Quaternion.Slerp(this.transform.rotation,book.transform.rotation, Time.deltaTime);
    }
            
    }
