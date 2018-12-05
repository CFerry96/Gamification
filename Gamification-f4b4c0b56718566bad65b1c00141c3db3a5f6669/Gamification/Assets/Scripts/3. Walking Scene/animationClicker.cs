﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationClicker : MonoBehaviour {

    Animator anim;
    bool click =false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void clicked()
    {
        Debug.Log("clicked");
        if (click == false)
        {
            Debug.Log("actually clicked");
            anim.SetBool("animPlay",true);
            click = true;
        }
        else if (click)
        {
            anim.SetBool("animPlay",false);
            click =false;
        }
    }
}
