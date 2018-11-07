using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endingScript : MonoBehaviour {
    public static bool sceneEnd = false;
    public float fadeTimer = 10f;
    public Image fadeOutScreen;
    private float alpha;
    private float fadeOutSpeed;
    public string ScenetoLoad;

    // Use this for initialization
    void Start()
    {
        fadeOutSpeed = fadeTimer;
        //StartCoroutine("EndLevel");
        //fadeOutScreen = GetComponent<Image>();
        alpha = 0;
        var tempColor = fadeOutScreen.color;
        tempColor.a = 0f;
        fadeOutScreen.color = tempColor;
    }
 	
	// Update is called once per frame
	void Update () {
        if(sceneEnd == true)
        {
            StartCoroutine("EndLevel");
            sceneEnd = false;
        }
    }
    IEnumerator EndLevel()
    {
        while (true)
        {
            fadeTimer -= Time.deltaTime;
            var tempColor = fadeOutScreen.color;
            tempColor.a += Time.deltaTime/fadeOutSpeed;
            fadeOutScreen.color = tempColor;
            if (fadeTimer <= 0)
            {
                SceneManager.LoadScene(ScenetoLoad);
            }
            yield return null;
        }
    }
}
