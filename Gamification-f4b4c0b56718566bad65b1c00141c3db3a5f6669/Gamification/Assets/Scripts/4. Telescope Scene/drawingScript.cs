using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawingScript : MonoBehaviour
{

    public static int clickNumber;
    public LineRenderer lr;
    public Material materialColour;
    public Renderer boxVisual;
    public int drawingMaxPoints;
    private bool alreadyClicked = false;
    private bool endingTriggered = false;
    public ParticleSystem ps;
    //public AudioSource note1, note2, note3;

    // Use this for initialization
    void Start()
    {
        boxVisual = GetComponent<Renderer>();
        materialColour = GetComponent<Renderer>().material;
        lr.positionCount = 0;
        Color c1 = new Color(237, 201, 20);
        //lr.SetColors(c1, c1);
        ps= GetComponent<ParticleSystem>();
        //ps[0].Stop();
        ps.Play();
        //ps.Stop();
        boxVisual.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (clickNumber >= drawingMaxPoints && !endingTriggered)
        {
            persistence.control.activated = true;
            persistence.control.Save();
            endingScript.sceneEnd = true;
            endingTriggered = true;

        }

        if (endingTriggered && !alreadyClicked)
        {
            boxVisual.enabled = false;
            ps.Stop();
        }

        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        //{
        //    // Get movement of the finger since last frame
        //    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        //    lr.SetPosition(clickNumber, touchDeltaPosition);

        //    // Move object across XY plane
        //    //transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
        //}

        //if (Input.GetMouseButtonDown(0))
        //{
        //    lr.positionCount++;
            
            
        //}
        //if (Input.GetMouseButton(0))
        //{
        //    lr.SetPosition(clickNumber, new Vector3(Input.mousePosition.z, Input.mousePosition.y, Input.mousePosition.x));
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    lr.positionCount--;
        //}
    }

    public void clicked()
    {
        if (!alreadyClicked && !endingTriggered)
        {
            boxVisual.enabled = true;
            ps.Play();
            lr.positionCount++;
            //if (lr.positionCount ==1)
            //{
            //    soundManager.soundBoy.note1.Play();
            //}
            //if (lr.positionCount == 2)
            //{
            //    soundManager.soundBoy.note2.Play();
            //}
            //if (lr.positionCount == 3)
            //{
            //    soundManager.soundBoy.note3.Play();
            //}
            //if (lr.positionCount == 4)
            //{
            //    soundManager.soundBoy.note1.Play();
            //}
            //if (lr.positionCount == 5)
            //{
            //    soundManager.soundBoy.note2.Play();
            //}
            //if (lr.positionCount == 6)
            //{
            //    soundManager.soundBoy.note3.Play();
            //}
            lr.SetPosition(clickNumber, transform.position);
            persistence.control.positionArray[clickNumber] = transform.position;
            Debug.Log(persistence.control.positionArray[clickNumber]);
            //gameController.control.point1 = 50000;

            clickNumber++;
            var tempColor = new Color(237, 201, 20, 255);
            materialColour.color = tempColor;
            //

            alreadyClicked = true;
        }

    }
}
