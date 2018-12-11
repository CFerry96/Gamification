using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightActivate : MonoBehaviour {

    public string KingdomName;
    GameObject Book;
    SwipeScript swipeScript;
    public GameObject Spotlight;
    public GameObject[] Spotlights;
    public GameObject arrow;


    // Use this for initialization
    void Start()
    {
        Book = GameObject.Find("New Book");
        Spotlight = GameObject.Find(KingdomName + " Spot Light");
        Spotlight.SetActive(false);
        swipeScript = Book.GetComponent<SwipeScript>();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        SwipeScript.canSwipe = false;
        arrow.SetActive(false);
        if (Spotlights.Length == 0)
        { 
            soundManager.soundBoy.StartCoroutine("fadeInLayers");
            for (int i = 0; i < Spotlights.Length; i++)
            {
                Spotlights[i].SetActive(false);
            }
            Spotlight.SetActive(true);
        }
        else if (Spotlights.Length > 0)
        {
            if (Spotlight != Spotlights[0])
            {
                for (int i = 0; i < Spotlights.Length; i++)
                {
                    Spotlights[i].SetActive(false);
                }
                Spotlight.SetActive(true);
            }
            else
            {

            }
        }
    }
    private void Update()
    {
        Spotlights = GameObject.FindGameObjectsWithTag("Spotlight");
    }
}
