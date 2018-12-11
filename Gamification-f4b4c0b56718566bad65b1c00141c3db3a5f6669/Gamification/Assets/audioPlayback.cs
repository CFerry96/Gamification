using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioPlayback : MonoBehaviour {
    AudioSource audio;
    // public Image playButton;
    public Renderer buttonToDisplay, YourArtText;


    // Use this for initialization
    void Start () {
        buttonToDisplay = GetComponent<Renderer>();
        audio = GetComponent<AudioSource>();
        //StartCoroutine(CheckForButton()); // changing data persistent script to load on awake over start fixed bugs requiring coroutine.
        if (persistence.control.activated)
        {
            buttonToDisplay.enabled = true;
            //PlayRecordingText.enabled = true;
            YourArtText.enabled = false;
            Debug.Log("button on");
        }
        else
        {
            buttonToDisplay.enabled = false;
           // PlayRecordingText.enabled = false;
            YourArtText.enabled = true;
        }
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
                //buttonToDisplay.SetActive(true);
                Debug.Log("button on");
            }
            yield return new WaitForSeconds(1);
        }
    }
}
