using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class persistence : MonoBehaviour
{

    public static persistence control;
    public float point1;
    public Vector3 firstPoint;
    public bool activated;
    public bool resetData;

    public Vector3[] positionArray = new Vector3[6];

    // Use this for initialization
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }

        if (resetData)
        {
            Reset();
        }
        Load();

    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            // Debug.Log("enabled");
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerSaves data = new PlayerSaves();
        data.point1 = point1;
        data.activated = activated;
        data.point1x = positionArray[0].x;
        data.point1y = positionArray[0].y;
        data.point1z = positionArray[0].z;

        data.point2x = positionArray[1].x;
        data.point2y = positionArray[1].y;
        data.point2z = positionArray[1].z;

        data.point3x = positionArray[2].x;
        data.point3y = positionArray[2].y;
        data.point3z = positionArray[2].z;

        data.point4x = positionArray[3].x;
        data.point4y = positionArray[3].y;
        data.point4z = positionArray[3].z;

        data.point5x = positionArray[4].x;
        data.point5y = positionArray[4].y;
        data.point5z = positionArray[4].z;

        data.point6x = positionArray[5].x;
        data.point6y = positionArray[5].y;
        data.point6z = positionArray[5].z;

        bf.Serialize(file, data);
        file.Close();

    }
    public void Reset()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerSaves data = new PlayerSaves();
        data.point1 = point1;
        activated = false;
        data.activated = activated;
        

        bf.Serialize(file, data);
        file.Close();

    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerSaves data = (PlayerSaves)bf.Deserialize(file);
            file.Close();

            point1 = data.point1;
            //firstPoint = new Vector3(data.point1x, data.point1y, data.point1z);

            positionArray[0] = new Vector3(data.point1x, data.point1y, data.point1z);
            positionArray[1] = new Vector3(data.point2x, data.point2y, data.point2z);
            positionArray[2] = new Vector3(data.point3x, data.point3y, data.point3z);
            positionArray[3] = new Vector3(data.point4x, data.point4y, data.point4z);
            positionArray[4] = new Vector3(data.point5x, data.point5y, data.point5z);
            positionArray[5] = new Vector3(data.point6x, data.point6y, data.point6z);

            activated = data.activated;
        }
    }

    void OnGUI()
    {
        if (activated)
        {
            //GUI.Label(new Rect(10, 10, 100, 30), "point1: " + point1);
        }
    }
}
[Serializable]
class PlayerSaves
{
    public float point1;
    public float point1x;
    public float point1y;
    public float point1z;

    public float point2x;
    public float point2y;
    public float point2z;

    public float point3x;
    public float point3y;
    public float point3z;

    public float point4x;
    public float point4y;
    public float point4z;

    public float point5x;
    public float point5y;
    public float point5z;

    public float point6x;
    public float point6y;
    public float point6z;
    public bool activated;
}
