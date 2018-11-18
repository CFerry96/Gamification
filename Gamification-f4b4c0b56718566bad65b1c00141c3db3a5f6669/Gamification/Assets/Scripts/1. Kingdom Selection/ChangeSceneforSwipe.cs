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

	// Use this for initialization
	void Start () {
        Book = GameObject.Find("New Book");
        Spotlight = GameObject.Find(KingdomName + " Spot Light");
        Spotlight.SetActive(false);
        touchswipe = Book.GetComponent<touchSwipe>();
        swipeScript = Book.GetComponent<SwipeScript>();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        for (int i = 0; i < Spotlights.Length; i++)
        {
            Spotlights[i].SetActive(false);
        }
        Spotlight.SetActive(true);
        touchswipe.PageNext = ScenetoLoad;
        swipeScript.PageNext = ScenetoLoad;
    }
    private void Update()
    {
        Spotlights = GameObject.FindGameObjectsWithTag("Spotlight");
    }
}
