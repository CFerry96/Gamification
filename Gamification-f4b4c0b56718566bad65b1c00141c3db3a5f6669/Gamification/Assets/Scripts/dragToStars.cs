using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragToStars : MonoBehaviour {
    Camera cam;


    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButton(0))
        {

            Ray ray = cam.ViewportPointToRay(cam.ScreenToViewportPoint(Input.mousePosition));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
                if (hit.transform.tag == "Interactable")
                {
                    //print("I'm looking at " + hit.transform.name);
                    hit.transform.gameObject.SendMessage("clicked");
                    //Destroy(hit.transform.gameObject);
                }
                else
                {
                    //print("I'm looking at nothing!");
                }
        }
    }
}
