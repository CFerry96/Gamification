﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class touchSwipe : MonoBehaviour {

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    private List<Vector3> touchPositions = new List<Vector3>(); //store all the touch positions in list
    Animator anim;
    public string PagePrev, PageNext;
    float animationTime = 0.5f, animationTime2 = 1.2f;
    //public GameObject rightSideObjects, leftSideObjects, settingsIcon, exitIcon;
    public GameObject[] leftsideObjects, rightsideObjects;
    public static bool canSwipe;
    AudioSource pageSound;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        pageSound = GetComponent<AudioSource>();
        canSwipe = false;
        dragDistance = Screen.height * 20 / 100; //dragDistance is 20% height of the screen 
        leftsideObjects = GameObject.FindGameObjectsWithTag("leftside");
        rightsideObjects = GameObject.FindGameObjectsWithTag("rightside");
    }

    // Update is called once per frame
    void Update()
    {

        foreach (Touch touch in Input.touches)  //use loop to detect more than one swipe
        { //can be ommitted if you are using lists 
          /*if (touch.phase == TouchPhase.Began) //check for the first touch
          {
              fp = touch.position;
              lp = touch.position;

          }*/

            if (touch.phase == TouchPhase.Moved) //add the touches to list as the swipe is being made
            {
                touchPositions.Add(touch.position);
            }

            if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                //lp = touch.position;  //last touch position. Ommitted if you use list
                fp = touchPositions[0]; //get first touch position from the list of touches
                lp = touchPositions[touchPositions.Count - 1]; //last touch position 

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal 
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            Debug.Log("Right Swipe");
                            StartCoroutine(swipePageRight());
                        }
                        else
                        {   //Left swipe
                            Debug.Log("Left Swipe");
                            //SceneManager.LoadScene("Page 2");
                            if (canSwipe)
                            {
                                StartCoroutine(swipePageLeft());
                            }
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            Debug.Log("Up Swipe");
                        }
                        else
                        {   //Down swipe
                            Debug.Log("Down Swipe");
                        }
                    }
                }
            }
            else
            {   //It's a tap as the drag distance is less than 20% of the screen height

            }
        }
    }

    IEnumerator swipePageLeft()
    {
        //exitIcon.SetActive(false);
        //rightSideObjects.SetActive(false);
        foreach (GameObject right in rightsideObjects)
        {
            right.SetActive(false);
        }
        anim.SetTrigger("nextPage");
        pageSound.Play();
        yield return new WaitForSeconds(animationTime);
        foreach (GameObject left in leftsideObjects)
        {
            left.SetActive(false);
        }
        //settingsIcon.SetActive(false);
        //leftSideObjects.SetActive(false);
        yield return new WaitForSeconds(animationTime2);
        SceneManager.LoadScene(PageNext);
        yield return null;
    }

    IEnumerator swipePageRight()
    {
        //leftSideObjects.SetActive(false);
        //settingsIcon.SetActive(false);
        foreach (GameObject left in leftsideObjects)
        {
            left.SetActive(false);
        }
        anim.SetTrigger("previousPage");
        pageSound.Play();
        yield return new WaitForSeconds(animationTime);
        foreach (GameObject right in rightsideObjects)
        {
            right.SetActive(false);
        }
        //exitIcon.SetActive(false);
        //rightSideObjects.SetActive(false);
        yield return new WaitForSeconds(animationTime2);
        SceneManager.LoadScene(PagePrev);
        yield return null;
    }
}
