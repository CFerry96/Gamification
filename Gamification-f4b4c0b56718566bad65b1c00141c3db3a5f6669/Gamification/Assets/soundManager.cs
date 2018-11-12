﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour {
    public static soundManager soundBoy = null;
    public AudioSource baseTrack;
    public AudioSource layerTrack;
    public float fadeInTime;
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
}
