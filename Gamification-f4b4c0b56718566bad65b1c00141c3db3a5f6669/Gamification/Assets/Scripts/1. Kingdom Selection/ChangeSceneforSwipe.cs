using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneforSwipe : MonoBehaviour {

    public string ScenetoLoad;
    SwipeScript swipeScript;
    GameObject Book;
    public string KingdomName;
    public GameObject Spotlight;
    public GameObject[] Spotlights;
    public GameObject arrow;


	// Use this for initialization
	void Start () {
        Book = GameObject.Find("New Book");
        Spotlight = GameObject.Find(KingdomName + " Spot Light");
        Spotlight.SetActive(false);
        swipeScript = Book.GetComponent<SwipeScript>();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        arrow.SetActive(true);
        SwipeScript.canSwipe = true; //pc build
        touchSwipe.canSwipe = true; //mobile build
        if (Spotlights.Length == 0)
        {
            soundManager.soundBoy.StartCoroutine("fadeInLayers");
            for (int i = 0; i < Spotlights.Length; i++)
            {
                Spotlights[i].SetActive(false);
            }
            Spotlight.SetActive(true);
            swipeScript.PageNext = ScenetoLoad;
        }
        else if (Spotlights.Length > 0)
        {
            if (Spotlight != Spotlights[0])
            {
                for (int i = 0; i < Spotlights.Length; i++)
                {
                    Spotlights[i].SetActive(false);
                }
                Spotlight.SetActive(true);
                swipeScript.PageNext = ScenetoLoad;
            }
            else {

            }
        }
    }
    private void Update()
    {
        Spotlights = GameObject.FindGameObjectsWithTag("Spotlight");
    }
}
