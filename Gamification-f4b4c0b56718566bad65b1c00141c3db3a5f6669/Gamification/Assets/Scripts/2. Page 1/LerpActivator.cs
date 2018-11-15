using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LerpActivator : MonoBehaviour {

    GameObject Book;
    public GameObject Camera;
    public LerpingCamera lc;

    private void Start()
    {
        Book = GameObject.Find("New Book");
    }

    void OnMouseDown()
    {
        Book.GetComponent<touchSwipe>().enabled = false;
        lc = Camera.GetComponent<LerpingCamera>();
        lc.enabled = true;
    }
}
