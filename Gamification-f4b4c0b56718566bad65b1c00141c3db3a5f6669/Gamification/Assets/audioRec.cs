using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioRec : MonoBehaviour
{
    public GameObject recordingButtons;
    public float recordingTime;
    float maxRecordingTime = 60f;
    AudioClip myAudioClip;
    public bool recording;
    public float fadeInTime;
    float fadeInCount;

    void Start() {
        maxRecordingTime = recordingTime;
    }

    void Update() {
        fadeInCount += Time.deltaTime;
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
            AudioSerialisation.SaveAudioClipToDisk(myAudioClip, "myfile");
        }
        if(fadeInCount >= fadeInTime)
        {
            recordingButtons.SetActive(true);
        }
    }
    

    void OnGUI()
    {
        
        GUI.Label(new Rect(500, 10, 100, 20), "Recording:" + maxRecordingTime);
        
        //if (GUI.Button(new Rect(10, 10, 60, 50), "Record"))
        //{
        //    Debug.Log("recording");
        //    RecordAudio();
        //}
        ////if (GUI.Button(new Rect(70, 10, 60, 50), "Stop recording")){
        ////    Microphone.End(null);
        ////}
        //if (GUI.Button(new Rect(10, 70, 60, 50), "Save"))
        //{
        //    //SavWav.Save("myfile", myAudioClip)"

        //    //        audio.Play();
        //    Microphone.End(null);
        //    recording = false;
        //    maxRecordingTime = recordingTime;

        //    AudioSerialisation.SaveAudioClipToDisk(myAudioClip, "myfile");
        //}
        //if (GUI.Button(new Rect(10,130, 60, 50), "Play"))
        //{
        //    AudioSource audio = GetComponent<AudioSource>();
        //    //audio.clip = myAudioClip;
        //    //audio.Play();
        //    AudioSerialisation.LoadAudioClipFromDisk(audio, "myfile");
        //    audio.Play();
            
        //}
    }
    public void RecordAudio()
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
            maxRecordingTime = recordingTime;

            AudioSerialisation.SaveAudioClipToDisk(myAudioClip, "myfile");
        }
    }

    public void PlayAudio()
    {
        AudioSource audio = GetComponent<AudioSource>();
        //audio.clip = myAudioClip;
        //audio.Play();
        AudioSerialisation.LoadAudioClipFromDisk(audio, "myfile");
        audio.Play();
    }

    public void SaveAudio()
    {
        Microphone.End(null);
        recording = false;
        maxRecordingTime = recordingTime;

        AudioSerialisation.SaveAudioClipToDisk(myAudioClip, "myfile");
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