using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneforSwipe : MonoBehaviour {

    public string ScenetoLoad;
    SwipeScript swipe;
    GameObject Book;

	// Use this for initialization
	void Start () {
        Book = GameObject.Find("New Book");
        swipe = Book.GetComponent<SwipeScript>();
	}

    // Update is called once per frame
    private void OnMouseDown()
    {
        swipe.PageNext = ScenetoLoad;
    }
}
