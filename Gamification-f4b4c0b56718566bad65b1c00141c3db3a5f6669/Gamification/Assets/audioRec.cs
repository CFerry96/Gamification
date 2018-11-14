using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioRec : MonoBehaviour
{

    AudioClip myAudioClip;

    void Start() { }
    void Update() { }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 60, 50), "Record"))
        {
            myAudioClip = Microphone.Start(null, false, 10, 44100);
        }
        if (GUI.Button(new Rect(70, 10, 60, 50), "Stop recording")){
            Microphone.End(null);
        }
        if (GUI.Button(new Rect(10, 70, 60, 50), "Save"))
        {
            //SavWav.Save("myfile", myAudioClip)"

            //        audio.Play();

            AudioSerialisation.SaveAudioClipToDisk(myAudioClip, "myfile");
        }
        if (GUI.Button(new Rect(10,130, 60, 50), "Play"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            //audio.clip = myAudioClip;
            //audio.Play();
            AudioSerialisation.LoadAudioClipFromDisk(audio, "myfile");
            audio.Play();
            
        }
    }
}