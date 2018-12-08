using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightAwake : MonoBehaviour {

    
    private void OnEnable()
    {
        this.GetComponent<Light>().intensity = 0;
    }

    // Update is called once per frame
    void Update () {
        if (this.GetComponent<Light>().intensity <= 23)
           {
            this.GetComponent<Light>().intensity++;
           }
	}
}
