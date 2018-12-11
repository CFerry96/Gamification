using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintTimer : MonoBehaviour {
    public GameObject hintText;
    objectInteraction obj;
    public float timeToWait = 3;

	// Use this for initialization
	void Start () {
        obj = GetComponent<objectInteraction>();
        hintText.SetActive(false);
        StartCoroutine(checkForInteraction());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator checkForInteraction()
    {
        yield return new WaitForSeconds(timeToWait);
        while (true)
        {
            if (!obj.clickedOnce)
            {
                hintText.SetActive(true);
            }
            else if (obj.clickedOnce)
            {
                hintText.SetActive(false);
            }
            yield return new WaitForSeconds(0.25f);
            
        }
    }
}
