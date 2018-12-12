using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioRec : MonoBehaviour
{
    public GameObject recordingButtons;
    public float recordingTime;
    float maxRecordingTime = 60f;
    AudioClip myAudioClip;
    public bool recording, optionsOpen;
    public float fadeInTime;
    float fadeInCount;
    public Text optionText;
    public Image recordButton, playButton;
    AudioSource audio;


    void Start() {
        maxRecordingTime = recordingTime;
        audio = GetComponent<AudioSource>();
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

        if (audio.isPlaying)
        {
            playButton.color = Color.green;
        }
        else
        {
            playButton.color = Color.white;
        }
        //if(fadeInCount >= fadeInTime)
        //{
        //    recordingButtons.SetActive(true);
        //}
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
            recordButton.color = Color.red;
            //StartCoroutine(CountDown());
        }
        else if (recording)
        {
            Microphone.End(null);
            recording = false;
            maxRecordingTime = recordingTime;

            AudioSerialisation.SaveAudioClipToDisk(myAudioClip, "myfile");
            recordButton.color = Color.white;
        }
    }

    public void PlayAudio()
    {
         if (recording)
        {
            Microphone.End(null);
            recording = false;
            maxRecordingTime = recordingTime;

            AudioSerialisation.SaveAudioClipToDisk(myAudioClip, "myfile");
            recordButton.color = Color.white;
        }
        //AudioSource audio = GetComponent<AudioSource>(); //
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

    //public void DisplayControls()
    //{
    //    if (!optionsOpen)
    //    {
    //        recordingButtons.SetActive(true);
    //        optionsOpen = true;
    //        optionText.text = "close menu";
    //        starNotePlay.interactable = false;
    //    }
    //    else if (optionsOpen)
    //    {
    //        optionsOpen = false;
    //        recordingButtons.SetActive(false);
    //        optionText.text = "record your journey";
    //        starNotePlay.interactable = true;
    //    }
    //}
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