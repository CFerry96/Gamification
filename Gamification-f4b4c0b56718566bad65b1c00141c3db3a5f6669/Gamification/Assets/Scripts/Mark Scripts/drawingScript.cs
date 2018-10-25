using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawingScript : MonoBehaviour {

    public static int clickNumber;
    public LineRenderer lr;
    public Material materialColour;
    public Renderer boxVisual;
    public int drawingMaxPoints;
    private bool alreadyClicked = false;
    private bool endingTriggered = false;
    public ParticleSystem ps;

	// Use this for initialization
	void Start () {
        boxVisual = GetComponent<Renderer>();
        materialColour = GetComponent<Renderer>().material;
        lr.positionCount = 0;
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
    }
	
	// Update is called once per frame
	void Update () {
		if(clickNumber >= drawingMaxPoints &&!endingTriggered)
        {
            endingScript.sceneEnd = true;
            endingTriggered = true;
            
        }

        if (endingTriggered&&!alreadyClicked)
        {
            boxVisual.enabled = false;
        }
	}

    public void clicked()
    {
        if (!alreadyClicked&&!endingTriggered)
        {
            ps.Play();
            lr.positionCount++;
            lr.SetPosition(clickNumber, transform.position);
            //gameController.control.point1 = 50000;
            //gameController.control.activated = true;
            //gameController.control.Save();
            clickNumber++;
            var tempColor = new Color(255, 0, 0, 0);
            materialColour.color = tempColor;
            
            alreadyClicked = true;
        }
        
    }
}
