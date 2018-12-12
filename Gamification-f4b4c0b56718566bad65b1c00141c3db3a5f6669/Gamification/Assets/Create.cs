using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour {

    public Camera cam;
    public GameObject book;
    private bool clicked = false;
    public AudioSource audio;

	void Update () {
        if(clicked == true)
        {
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, book.transform.rotation, Time.deltaTime);
        }
	}

    private void OnMouseDown()
    {
        audio.Play();
        clicked = true;
    }
            
    }
