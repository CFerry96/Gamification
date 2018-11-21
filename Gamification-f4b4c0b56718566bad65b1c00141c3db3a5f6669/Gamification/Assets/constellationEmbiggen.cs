using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constellationEmbiggen : MonoBehaviour {
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float initialZ;
    public float finalZ;
    public float rateOfExpansion;

	// Use this for initialization
	void Start () {
        startPoint = new Vector3(transform.position.x, transform.position.y, initialZ);
        endPoint = new Vector3(transform.position.x, transform.position.y, finalZ);
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z >= finalZ)
        {
            transform.position += new Vector3(0, 0, -rateOfExpansion * Time.deltaTime);
        }
	}
}
