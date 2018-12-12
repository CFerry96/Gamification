using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectInteraction : MonoBehaviour {
    public Camera cam;
    public bool clickedOnce;
    public AudioSource clickSound;

    // Use this for initialization
    void Start() {
        clickSound = GetComponent<AudioSource>();
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) { 

        Ray ray = cam.ViewportPointToRay(cam.ScreenToViewportPoint(Input.mousePosition));
        RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
                if (hit.transform.tag == "Interactable")
                {
                    if (clickSound != null)
                    {
                        clickSound.Play();
                    }
                    //print("I'm looking at " + hit.transform.name);
                    hit.transform.gameObject.SendMessage("clicked");
                    clickedOnce = true;
                    //Destroy(hit.transform.gameObject);
                }
                else
                {
                    //print("I'm looking at nothing!");
                }
    }
}

}

