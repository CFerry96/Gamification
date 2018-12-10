using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneforSwipe : MonoBehaviour {

    public string ScenetoLoad;
    SwipeScript swipeScript;
    touchSwipe touchswipe;
    GameObject Book;
    public string KingdomName;
    public GameObject Spotlight;
    public GameObject[] Spotlights;
    public GameObject arrow;


	// Use this for initialization
	void Start () {
        //arrow = GameObject.Find("Arrow UI_0");
        Book = GameObject.Find("New Book");
        Spotlight = GameObject.Find(KingdomName + " Spot Light");
        Spotlight.SetActive(false);
        touchswipe = Book.GetComponent<touchSwipe>();
        swipeScript = Book.GetComponent<SwipeScript>();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (Spotlights.Length == 0)
        {
            arrow.SetActive(true);
            soundManager.soundBoy.StartCoroutine("fadeInLayers");
            for (int i = 0; i < Spotlights.Length; i++)
            {
                Spotlights[i].SetActive(false);
            }
            Spotlight.SetActive(true);
            touchswipe.PageNext = ScenetoLoad;
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
                touchswipe.PageNext = ScenetoLoad;
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
