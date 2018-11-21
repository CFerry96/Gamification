using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meditationBlackscreen : MonoBehaviour {

    SpriteRenderer sp;
    public float opacity;
    float theta;
    public float thetaSpeed;
    public float opacityModifier;
    public float sinWaveMultiplier;
	// Use this for initialization
	void Start () {
        sp = GetComponent<SpriteRenderer>();
        theta = -1;
	}
	
	// Update is called once per frame
	void Update () {
        theta += Time.deltaTime*thetaSpeed;
        opacity = Mathf.Sin(theta )* sinWaveMultiplier;
        sp.color = new Color(1, 1, 1, opacity+opacityModifier);
	}
}
