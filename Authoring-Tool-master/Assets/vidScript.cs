using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class vidScript : MonoBehaviour
{

    public RawImage image;

    public VideoClip videoToPlay;

    private VideoPlayer videoPlayer;
    private VideoSource videoSource;

    private AudioSource audioSource;
    private string dataPath;
    
    public string vidSrc;
    public bool flag=false;

    public long initTime;
    public long destroyTime;
    public long startTime;
    public long endTime;

    // Use this for initialization
    void Start()
    {

        //this.dataPath = Application.dataPath;
        //StreamReader reader = new StreamReader(dataPath+"/Resources/scriptSample.txt");

        //Debug.Log(reader.ReadLine());
        //Debug.Log(reader.ReadLine());
        
        //Application.runInBackground = true;
        //StartCoroutine(playVideo());
        
    }

    public void Starter()
    {
        Application.runInBackground = true;
        StartCoroutine(playVideo());

    }

    IEnumerator playVideo()
    {
        //while (!flag) ;

        //string str = Resources.Load<TextAsset>("vidSelector").text;
        videoToPlay = Resources.Load<VideoClip>("Videos_1/"+vidSrc);
        //videoSource = Resources.Load<VideoClip>("SampleVideo");

        //Add VideoPlayer to the GameObject
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        //Add AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();

        videoPlayer.playOnAwake = false;
        //Disable Play on Awake for both Video and Audio
        audioSource.playOnAwake = false;
        audioSource.Pause();

        //We want to play from video clip not from url

        videoPlayer.source = VideoSource.VideoClip;

        // Vide clip from Url
        //videoPlayer.source = VideoSource.Url;
        //videoPlayer.url = "https://www.sample-videos.com/video123/mp4/720/big_buck_bunny_720p_5mb.mp4";


        //Set Audio Output to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        //Assign the Audio from Video to AudioSource to be played
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        //Set video To Play then prepare Audio to prevent Buffering
        videoPlayer.clip = videoToPlay;
        videoPlayer.Prepare();

        //Wait until video is prepared
        WaitForSeconds waitTime = new WaitForSeconds(0.1f);
        while (!videoPlayer.isPrepared)
        {
            Debug.Log("Preparing Video");
            //Prepare/Wait for 5 sceonds only
            yield return waitTime;
            //Break out of the while loop after 5 seconds wait
            break;
        }

        Debug.Log("Done Preparing Video");

        if (videoPlayer)
        {
            Debug.Log("HMM");
        }

        //Assign the Texture from Video to RawImage to be displayed
        //image.texture = videoPlayer.texture;
        videoPlayer.frame = (long)(videoPlayer.frameRate * startTime);
        //Play Video
        videoPlayer.Play();

        //Play Sound
        audioSource.Play();

        yield return new WaitForSeconds((float)(endTime-startTime));
        videoPlayer.Stop();
        audioSource.Stop();

        //Debug.Log("Playing Video");
        //while (videoPlayer.isPlaying)
        //{
        //    Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
        //    yield return null;
        //}
        //Debug.Log("Done Playing Video");
        
    }

    public void valSetter(string src=null, long sTime=0, long eTime=0, long vidStart=0, long vidEnd=0)
    {
        vidSrc = src;
        initTime = sTime;
        destroyTime = eTime;
        startTime = vidStart;
        endTime = vidEnd;
        flag = true;
    }
}