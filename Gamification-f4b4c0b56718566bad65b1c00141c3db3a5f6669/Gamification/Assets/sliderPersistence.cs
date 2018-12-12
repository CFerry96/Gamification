using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderPersistence : MonoBehaviour {
    public static float musicSlider, effectsSlider;


    // Use this for initialization
    private void Awake()
    {
        musicSlider = 1;
        effectsSlider = 1;
    }

    void Start () {
        
       
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
