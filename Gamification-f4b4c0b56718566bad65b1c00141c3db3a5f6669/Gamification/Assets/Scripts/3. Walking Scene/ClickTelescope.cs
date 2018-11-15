using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickTelescope : MonoBehaviour {

    public Image Black;
    public Transform target;
    public string SceneToLoad;

    public float blackoutTime;
    public Transform playerTransform;
    public movementScript ms;
    public Transform finalWaypoint;
    bool clicked = false;
    GameObject camera;
    GyroControls gyroControls;

    private void Start()
    {
        camera = GameObject.Find("Camera");
        gyroControls = camera.GetComponent<GyroControls>();
    }

    void OnMouseDown()
    {
        if (Vector3.Distance(playerTransform.position, this.transform.position) <= Vector3.Distance(finalWaypoint.position, this.transform.position) + 1)
        {
            Debug.Log("clicked");
            clicked = true;
        }
    }

    private void Update()
    {
        if (clicked == true)
        {
            playerTransform.position = Vector3.Lerp(playerTransform.position, target.position, Time.deltaTime * blackoutTime);

            var tempVariable = Black.color;
            tempVariable.a += Time.deltaTime / 2.5f;
            Black.color = tempVariable;

            playerTransform.rotation = Quaternion.RotateTowards(playerTransform.transform.rotation, target.rotation, 90 * Time.deltaTime);

            ms.enabled = false;
            gyroControls.enabled=false;

            StartCoroutine(SceneChange());

            
        }
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneToLoad);
    }
}
