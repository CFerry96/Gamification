using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelescopeScene : MonoBehaviour {

    public string SceneToLoad;
    public Transform playerTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Vector3.Distance(playerTransform.position, this.transform.position));
	}

    private void OnMouseDown()
    {
        if (Vector3.Distance(playerTransform.position, this.transform.position) <= 6)
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}
