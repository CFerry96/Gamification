using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour {
    public static soundManager soundBoy = null;
    public AudioSource baseTrack, layerTrack, finalTrack;
    public AudioSource note1, note2, note3;
    public float fadeInTime;
    public float fadeOutTime;
    //public static soundManager instance = null;

    

	// Use this for initialization
	void Awake () {
      if(soundBoy == null)
        {
           // DontDestroyOnLoad(gameObject);
            soundBoy = this;
        }
        else if(soundBoy !=this)
        {
            Destroy(gameObject);
        }
       
	}

    private void Start()
    {
        layerTrack.volume = 0;
    }
    // Update is called once per frame
    void Update () {
        //musicSource.volume += Time.deltaTime /5;
		
	}

    public void playNote(AudioSource note)
    {
        note.Play();
    }
    IEnumerator fadeInLayers()
    {
        bool fadeIn = true;
        while (fadeIn)
        {
            layerTrack.volume += Time.deltaTime/fadeInTime;
            if(layerTrack.volume == 1)
            {
                fadeIn = false;
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
    IEnumerator endingLayers()
    {
        bool fadeIn = true;
        //finalTrack.volume = 1;
        while (fadeIn)
        {
            finalTrack.volume += Time.deltaTime / fadeInTime;
            if (finalTrack.volume == 1)
            {
                fadeIn = false;
            }
            yield return new WaitForSeconds(0.1f);
        }
        while (!fadeIn)
        {
            baseTrack.volume -= Time.deltaTime / fadeOutTime;
            layerTrack.volume -= Time.deltaTime / fadeOutTime;
            finalTrack.volume -= Time.deltaTime / fadeOutTime;
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
