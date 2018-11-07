using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLightRotation : MonoBehaviour {
    public movementScript movS;
    float timeMultiplier = 10f;
    public float playerSpeedMultiplier;

    float sunX = -5;
	// Use this for initialization
	void Start () {
        timeMultiplier = movS.playerSpeed*playerSpeedMultiplier;
	}
	
	// Update is called once per frame
	void Update () {
        sunX+= Time.deltaTime *timeMultiplier;
        transform.rotation = Quaternion.Euler(sunX,14,13);
	}
}
