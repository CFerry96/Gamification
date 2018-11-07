using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraSwing : MonoBehaviour {
    public Transform leftView;
    public Transform defaultView;
    public Transform rightView;
    private Transform currentView;

   
    public Transform upView;
   

    public Button leftButton;
    public Button rightButton;
    public Button upButton;
    public Button downButton;
    private Image r1;
    private Image r2;
    
    

    public int viewNumber;
    public int viewUpNumber;

	// Use this for initialization
	void Start () {
        currentView = defaultView;
        Button btn1 = leftButton.GetComponent<Button>();
        Button btn2 = rightButton.GetComponent<Button>();
        Button btn3 = upButton.GetComponent<Button>();
        Button btn4 = downButton.GetComponent<Button>();
        Image r2 = rightButton.GetComponent<Image>();
        //Renderer r1 = leftButton.GetComponent<Renderer>();
        //Renderer r2 = rightButton.GetComponent<Renderer>();

        btn1.onClick.AddListener(leftButtonClick);
        btn2.onClick.AddListener(rightButtonClick);
        btn3.onClick.AddListener(upButtonClick);
        btn4.onClick.AddListener(downButtonClick);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("a")){
            viewNumber--;
        }

        if (Input.GetKeyDown("d"))
        {
            viewNumber++;
        }

        if (Input.GetKeyDown("w"))
        {
            viewNumber = 0;
            viewUpNumber++;
        }

        if (Input.GetKeyDown("s"))
        {
            viewUpNumber--;
        }

        if (viewNumber < -1)
        {
            viewNumber = -1;
            
        }

        if(viewNumber > 1)
        {
            viewNumber = 1;
           
        }

        if(viewNumber == -1)
        {
            viewUpNumber = 0;
            currentView = leftView;
            Image r1 = leftButton.GetComponent<Image>();
            r1.enabled = false;

        }

        if(viewNumber == 0)
        {
            currentView = defaultView;
            Image r1 = leftButton.GetComponent<Image>();
            r1.enabled = true;
            Image r2 = rightButton.GetComponent<Image>();
            r2.enabled = true;
           
        }

        if(viewNumber == 1)
        {
            viewUpNumber = 0;
            currentView = rightView;
            Image r2 = rightButton.GetComponent<Image>();
            r2.enabled = false;
           
        }

        if(viewUpNumber < 0)
        {
            viewUpNumber = 0;
        }
        if(viewUpNumber > 1)
        {
            
            viewUpNumber = 1;
        }

        if(viewUpNumber == 1)
        {
            viewNumber = 0;
            Image r3 = upButton.GetComponent<Image>();
            r3.enabled = false;
            Image r4 = downButton.GetComponent<Image>();
            r4.enabled = true;
            currentView = upView;
        }

        if (viewUpNumber == 0)
        {
            
            Image r3 = upButton.GetComponent<Image>();
            r3.enabled = true;
            Image r4 = downButton.GetComponent<Image>();
            r4.enabled = false;
            
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, currentView.rotation, Time.deltaTime*1.5f);
	}

    void leftButtonClick()
    {
        viewNumber--;
    }

    void rightButtonClick()
    {
        viewNumber++;
    }

    void upButtonClick()
    {
        viewNumber = 0;
        viewUpNumber++;
    }

    void downButtonClick()
    {
        viewUpNumber--;
    }
}