using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LerpingCamera : MonoBehaviour
{
    public Image Black;
    public Transform target;
    public float blackoutTime;
    public GameObject drawing;
    public GameObject yourArt;
    public string SceneToLoad;


    // Use this for initialization
    void Awake()
    {   if (persistence.control.activated != true)
        {
            drawing.SetActive(false);
            yourArt.SetActive(false);
        }
        
    }

    private void Start()
    {
        StartCoroutine(SceneChange());
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(transform.position,target.transform.position, Time.deltaTime / blackoutTime);
        transform.LookAt(target.transform.parent);

        transform.rotation = Quaternion.RotateTowards(this.transform.rotation, target.rotation, 90 * Time.deltaTime / blackoutTime);
       
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(2);
        drawing.SetActive(false);
        yourArt.SetActive(false);
        yield return new WaitForSeconds(3);
        while (true)
        {
            var tempVariable = Black.color;
            tempVariable.a += Time.deltaTime / 1f;
            Black.color = tempVariable;

            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(SceneToLoad);
        }
    }

}
