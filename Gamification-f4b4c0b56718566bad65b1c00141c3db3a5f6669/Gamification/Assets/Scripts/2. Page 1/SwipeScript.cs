using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipeScript : MonoBehaviour {

    private bool tap, swipeLeft, swipeRight;
    private bool isDragging;
    private Vector2 startTouch, swipeDelta;
    public string PagePrev, PageNext;
    public Animator pageTurn;
    public float timeToTurnPage;
    public Animator anim;
    public GameObject titles;

    private void Start()
    {
        //anim = GetComponent<Animator>();
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

        if(Input.touches.Length > 0)
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
            titles.SetActive(false);
            swipeRight = false;
        }
        else if(swipeLeft == true)
        {
            StartCoroutine("swipePageLeft");
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
        anim.SetTrigger("nextPage");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(PageNext);
        yield return null;

    }

    IEnumerator swipePageRight()
    {
        while (true)
        {
            anim.SetTrigger("previousPage");
            timeToTurnPage -= Time.deltaTime;
            if(timeToTurnPage<= 0)
            {
                SceneManager.LoadScene(PagePrev);
            }
            yield return null;
        }
    }

}

