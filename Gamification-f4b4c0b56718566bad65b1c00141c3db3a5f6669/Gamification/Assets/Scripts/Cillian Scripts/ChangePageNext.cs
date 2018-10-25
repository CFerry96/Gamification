using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangePageNext : MonoBehaviour
{

    public string nextPage;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag()
    {
            print("test");
        SceneManager.LoadScene(nextPage);
    }
}