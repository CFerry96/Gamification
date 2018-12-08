using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constellationPoints : MonoBehaviour {
    public GameObject starPrefab;
    public GameObject[] starryBoys = new GameObject[6];

	// Use this for initialization
	void Start () {
        for(int i=0; i< 6; i++)
        {
            starryBoys[i] = (GameObject)Instantiate(starPrefab, new Vector3( (transform.position.x + persistence.control.positionArray[i].x), 
                (transform.position.y + persistence.control.positionArray[i].y), 
                (transform.position.z +persistence.control.positionArray[i].z)), 
                Quaternion.identity);
            starryBoys[i].transform.parent = gameObject.transform;
            
        }
        


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
