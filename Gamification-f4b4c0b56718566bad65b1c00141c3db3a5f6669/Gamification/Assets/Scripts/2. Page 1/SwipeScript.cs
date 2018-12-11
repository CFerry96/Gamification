using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipeScript : MonoBehaviour {

    private bool tap, swipeLeft, swipeRight;
    private bool isDragging;
    private Vector2 startTouch, swipeDelta;
    public string PagePrev, PageNext;
    float timeToTurnPage = 1;
    Animator anim;
    float animationTime = 0.5f, animationTime2 = 1.2f;
    public GameObject[] leftsideObjects, rightsideObjects;
    public static bool canSwipe;
    AudioSource pageSound;

    private void Start()
    {
        pageSound = GetComponent<AudioSource>();
        canSwipe = false;
        anim = GetComponent<Animator>();
        leftsideObjects = GameObject.FindGameObjectsWithTag("leftside");
        rightsideObjects = GameObject.FindGameObjectsWithTag("rightside");
    }


    private void Update ()
    {
        tap = swipeLeft = swipeRight = false;

        #region Standalone Inputs

        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Reset();
        }
        #endregion

        #region Mobile Inputs

        /*if(Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }
        }
        */
        #endregion

        //Calculate the distance 
        swipeDelta = Vector2.zero;
        if(isDragging)
        {
            if(Input.touches.Length >0)
            {
                swipeDelta = Input.touches[0].position = startTouch;
            }
            else if(Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }
        
        //Did user cross deadzone
        if(swipeDelta.magnitude > 125)
            {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or RIght
                if (x < 0)
                {
                    swipeLeft = true;
                }
                else 
                {
                    swipeRight = true;
                }
            }
            

                Reset();
        }

        if(swipeRight == true)
        {
            StartCoroutine("swipePageRight");
            swipeRight = false;
        }
        else if(swipeLeft == true)
        {
            if (canSwipe)
            {
                StartCoroutine("swipePageLeft");
            }
        }

    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight;  } }
   
    IEnumerator swipePageLeft()
    {
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
        yield return new WaitForSeconds(animationTime2);
        SceneManager.LoadScene(PageNext);
        yield return null;
    }

    IEnumerator swipePageRight()
    {
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
        yield return new WaitForSeconds(animationTime2);
        SceneManager.LoadScene(PagePrev);
        yield return null;
    }

}

