using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangePagePrev : MonoBehaviour {

    public string prevPage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if(gameObject.tag == "button")
        {
            SceneManager.LoadScene("prevPage");
        }
    }
}
