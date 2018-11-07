using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectKingdom : MonoBehaviour {
    public string Kingdom;
    public Animator anim;
    public float timeToWait;
    public float iconDisappearingTime;
    public GameObject leftPage;
    public GameObject rightPage;


    private void OnMouseDown()
    {
        StartCoroutine("nextPage");
        
        // SceneManager.LoadScene(Kingdom);
    }

    IEnumerator nextPage()
    {
        while (true)
        {
            anim.SetTrigger("nextPage");
            rightPage.SetActive(false);
            yield return new WaitForSeconds(iconDisappearingTime);
            leftPage.SetActive(false);
            yield return new WaitForSeconds(timeToWait);
            //Debug.Log("Load Scene");
            SceneManager.LoadScene(Kingdom);
        }
    }
}
