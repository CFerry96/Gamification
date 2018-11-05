using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZoomToTelscope : MonoBehaviour {

    public Image Black;
    public Transform target;
    public string SceneToLoad;
      
    public float blackoutTime;
    public Transform playerTransform;
    public movementScript ms;

        // Update is called once per frame
        void Update()
        {
            if (Vector3.Distance(playerTransform.position, this.transform.position) <= 6)
            {
                transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * blackoutTime);
              
                var tempVariable = Black.color;
                tempVariable.a += Time.deltaTime / 2.5f;
                Black.color = tempVariable;
            
                transform.rotation = Quaternion.RotateTowards(this.transform.rotation, target.rotation, 90 * Time.deltaTime);

                ms.enabled = false;

                StartCoroutine(SceneChange());
            }
        }

        IEnumerator SceneChange()
         {
            yield return new WaitForSeconds(4);
            SceneManager.LoadScene(SceneToLoad);
         }
}
