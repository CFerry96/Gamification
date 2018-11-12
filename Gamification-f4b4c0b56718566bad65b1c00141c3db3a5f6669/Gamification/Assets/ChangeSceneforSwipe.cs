using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneforSwipe : MonoBehaviour {

    public string ScenetoLoad;
    public SwipeScript swipe;

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    private void OnMouseDown()
    {
        swipe.PageNext = ScenetoLoad;
    }
}
