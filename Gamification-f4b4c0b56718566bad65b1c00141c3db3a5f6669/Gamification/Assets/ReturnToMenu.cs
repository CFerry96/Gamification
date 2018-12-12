using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToMenu : MonoBehaviour {

    //public Text button;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
      

    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Page 1");
    }
    
}
