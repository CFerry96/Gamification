using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starNotePlay : MonoBehaviour {
    public AudioSource note1, note2, note3;
    float temInt;

	// Use this for initialization
	void Start () {
        temInt = Random.Range(0, 3);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void clicked()
    
    {
        
        if (temInt <= 1)
        {
            note1.Play();
            Debug.Log("note1");
        }
        else if (temInt <= 2)
        {
            note2.Play();
            Debug.Log("note2");
        }
        else if (temInt <= 3)
        {
            note3.Play();
            Debug.Log("note3");
        }
    }
}
