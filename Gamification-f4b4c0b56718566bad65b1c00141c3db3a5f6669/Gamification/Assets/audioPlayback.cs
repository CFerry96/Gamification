using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioPlayback : MonoBehaviour {
    AudioSource audio;
    public Image playButton;
    public GameObject buttonToDisplay;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        //StartCoroutine(CheckForButton()); // cannot check for this in start as it takes a while for the pesistent data check to load the file.
        
	}
	
	// Update is called once per frame
	void Update () {
        if (audio.isPlaying)
        {
           // playButton.color = Color.green;
        }
        else
        {
            //playButton.color = Color.white;
        }
        
    }

    public void clicked()
    {
        //AudioSource audio = GetComponent<AudioSource>(); //
        //audio.clip = myAudioClip;
        //audio.Play();
        AudioSerialisation.LoadAudioClipFromDisk(audio, "myfile");
        audio.Play();
        Debug.Log("playing file");
    }

    IEnumerator CheckForButton()
    {
        while (true)
        {
            if (persistence.control.activated)
            {
                buttonToDisplay.SetActive(true);
                Debug.Log("button on");
            }
            yield return new WaitForSeconds(1);
        }
    }
}
