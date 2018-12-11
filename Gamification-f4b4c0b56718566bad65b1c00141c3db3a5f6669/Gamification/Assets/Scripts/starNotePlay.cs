using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starNotePlay : MonoBehaviour {
    public AudioSource note1, note2, note3;
    int temInt;
    public static bool interactable;

	// Use this for initialization
	void Start () {
        interactable = true;
        temInt = Random.Range(0, 3);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void clicked()
    
    {
        if (interactable)
        {
            if (temInt == 0)
            {
                note1.Play();
                Debug.Log("note1");
            }
            else if (temInt == 1)
            {
                note2.Play();
                Debug.Log("note2");
            }
            else if (temInt == 2)
            {
                note3.Play();
                Debug.Log("note3");
            }
        }
    }
}
