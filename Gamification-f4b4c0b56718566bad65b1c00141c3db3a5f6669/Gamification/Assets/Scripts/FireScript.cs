using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    private bool lit = false;
    public GameObject Fire;

    private void OnMouseDown()
    {
        if(lit==false)
        {
            lit = true;
        }
        else if(lit==true)
        {
            lit = false;
        }
    }

    private void Update()
    {
        if (lit == true)
        {
            Fire.SetActive(true);
        }
        else if (lit == false)
        {
            Fire.SetActive(false);
        }
    }
}
