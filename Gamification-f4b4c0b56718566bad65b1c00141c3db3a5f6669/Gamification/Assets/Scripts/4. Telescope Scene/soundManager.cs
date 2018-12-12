using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundManager : MonoBehaviour {
    public static soundManager soundBoy = null;
    public AudioSource baseTrack, layerTrack, finalTrack;
    public AudioSource note1, note2, note3;
    public float fadeInTime;
    public float fadeOutTime;
    //public static soundManager instance = null;
    public float musicVolume;
    public float soundEffectsVolume;
    public Slider musicSlider;
    public Slider effectsSlider;
    public bool completedTrack;

    

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
        //musicSlider.value = sliderPersistence.musicSlider;
        //effectsSlider.value = sliderPersistence.effectsSlider;
        completedTrack = false;
        musicSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        effectsSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        layerTrack.volume = 0;
        musicVolume = 1;
        soundEffectsVolume = 1;
    }
    // Update is called once per frame
    void Update () {
        //musicSource.volume += Time.deltaTime /5;
		
	}

    public void playNote(AudioSource note)
    {
        note.Play();
    }

    public void ValueChangeCheck()
    {
        // Debug.Log(musicSlider.value);
        baseTrack.volume = musicSlider.value;
        if (completedTrack)
        {
            layerTrack.volume = musicSlider.value;
            finalTrack.volume = musicSlider.value;
        }
        note1.volume = effectsSlider.value;
        note2.volume = effectsSlider.value;
        note3.volume = effectsSlider.value;

        //sliderPersistence.musicSlider = musicSlider.value;
        //sliderPersistence.effectsSlider = effectsSlider.value;
    }
    IEnumerator fadeInLayers()
    {
        bool fadeIn = true;
        while (fadeIn)
        {
            layerTrack.volume += Time.deltaTime/fadeInTime;
            if(layerTrack.volume >= musicSlider.value)
            {
                fadeIn = false;
                layerTrack.volume = musicSlider.value;
                completedTrack = true;
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
            if (finalTrack.volume >= musicSlider.value)
            {
                fadeIn = false;
                finalTrack.volume = musicSlider.value;
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
