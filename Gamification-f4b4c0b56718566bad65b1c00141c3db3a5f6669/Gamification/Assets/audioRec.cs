using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioRec : MonoBehaviour
{
    public float recordingTime;
    float maxRecordingTime = 60f;
    AudioClip myAudioClip;
    public bool recording;

    void Start() {
        maxRecordingTime = recordingTime;
    }

    void Update() {
        if (recording == true)
        {
            maxRecordingTime -= Time.deltaTime;
            Debug.Log(maxRecordingTime);
        }
        if (maxRecordingTime <= 0)
        {
            Microphone.End(null);
            recording = false;
            maxRecordingTime = recordingTime;
        }
    }
    

    void OnGUI()
    {
        
         GUI.Label(new Rect(500, 10, 100, 20), "Recording:" + maxRecordingTime);
        
        if (GUI.Button(new Rect(10, 10, 60, 50), "Record"))
        {
            Debug.Log("recording");
            RecordAudio();
        }
        //if (GUI.Button(new Rect(70, 10, 60, 50), "Stop recording")){
        //    Microphone.End(null);
        //}
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
    void RecordAudio()
    {
        if (!recording)
        {
            
            myAudioClip = Microphone.Start(null, false, 10, 44100);
            Debug.Log("recording for real");
            recording = true;
            //StartCoroutine(CountDown());
        }
        else if (recording)
        {
            Microphone.End(null);
            recording = false;
        }
    }
    /* IEnumerator CountDown()
     {

         while (recording == true)
         {
             maxRecordingTime -= Time.deltaTime;
         }
         yield return null;
         
}
*/
}