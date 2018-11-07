using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectKingdom : MonoBehaviour {
    public string Kingdom;
    public Animator anim;
    public float timeToWait;


    private void OnMouseDown()
    {
        StartCoroutine("nextPage");
        anim.SetTrigger("nextPage");
        // SceneManager.LoadScene(Kingdom);
    }

    IEnumerator nextPage()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(timeToWait);
            SceneManager.LoadScene(Kingdom);
        }
    }
}
