using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpingCamera : MonoBehaviour
{
    public Image Black;
    public Transform target;
    public float blackoutTime;




    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(transform.position,target.transform.position, Time.deltaTime * blackoutTime);
        transform.LookAt(target.transform.parent);

        var tempVariable = Black.color;
        tempVariable.a += Time.deltaTime / 2.5f;
        Black.color = tempVariable;

        transform.rotation = Quaternion.RotateTowards(this.transform.rotation, target.rotation, 90 * Time.deltaTime);

    }

}
