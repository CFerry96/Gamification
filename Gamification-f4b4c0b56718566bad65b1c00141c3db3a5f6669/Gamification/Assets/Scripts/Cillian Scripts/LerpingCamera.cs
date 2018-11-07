using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LerpingCamera : MonoBehaviour
{
    public Image Black;
    public Transform target;
    public float blackoutTime;
    public GameObject drawing;
    public GameObject yourArt;


    // Use this for initialization
    void Start()
    {
        drawing.SetActive(false);
        yourArt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(transform.position,target.transform.position, Time.deltaTime / blackoutTime);
        transform.LookAt(target.transform.parent);

        transform.rotation = Quaternion.RotateTowards(this.transform.rotation, target.rotation, 90 * Time.deltaTime / blackoutTime);

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Interactable")
        {
            var tempVariable = Black.color;
            tempVariable.a += Time.deltaTime / 1f;
            Black.color = tempVariable;
        }
    }

}
