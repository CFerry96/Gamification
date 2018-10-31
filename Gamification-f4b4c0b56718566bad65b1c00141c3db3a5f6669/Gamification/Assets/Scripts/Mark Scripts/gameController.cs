using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class gameController : MonoBehaviour {

    public static gameController control;
    public float point1;
    public bool activated;

	// Use this for initialization
	void Awake () {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }

       
		
	}

    private void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update () {
        if (activated)
        {
            Debug.Log("enabled");
        }
	}

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.point1 = point1;
        data.activated = activated;

        bf.Serialize(file, data);
        file.Close();

    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            point1 = data.point1;
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
class PlayerData
{
    public float point1;
    public bool activated;
}
