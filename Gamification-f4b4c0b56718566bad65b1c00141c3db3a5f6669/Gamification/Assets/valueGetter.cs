using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class valueGetter : MonoBehaviour {
    sliderPersistence sp;
    GameObject sliderObject;
    public Slider musicSlider;
    public Slider effectsSlider;

    // Use this for initialization
    void Start () {
        

        musicSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        effectsSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ValueChangeCheck()
    {

        sliderPersistence.musicSlider = musicSlider.value;
        sliderPersistence.effectsSlider = effectsSlider.value;
    }
}
