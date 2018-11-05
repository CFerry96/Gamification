using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectKingdom : MonoBehaviour {
    public string Kingdom;


    private void OnMouseDown()
    {
        SceneManager.LoadScene(Kingdom);
    }
}
