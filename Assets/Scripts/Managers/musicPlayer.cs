using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class musicPlayer : MonoBehaviour
{
    public sphereShader sphereManager;
    private bool menuOn;  // is music player menu enabled on screen
    public GameObject waves;  // Parent gameObject of all waves in scene  
    public GameObject panel;  // Panel to play the song
    public GameObject pauseButton;   
    public GameObject playButton;
    public GameObject vrHandle;

    public Text nameOfSong;   // object that represent name of song in scene
    public Text totalTimeObject;   // object that represent total length of song in scene
    public Text currentTimeObject;   // object that represent current time of song in scene
    public Slider timeScaler;   // slider with song loading


    private AudioSource audioSource;  // gameobject with audio source on it 
    private float step; // the length of step to move pointed on track scale



    public void Start()
    {
        audioSource = this.GetComponent<AudioSource>();

        Play();
    }

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Back)) {
            if (!menuOn)
            {
                Pause();   // stop playing song
                waves.SetActive(false);  // make waves unvisable 
                sphereManager.FadeOut();  // make sphere turn dark
                menuOn = true;
                panel.SetActive(true);
            }
            else {
                waves.SetActive(true);
                sphereManager.FadeIn();
                menuOn = false;
                panel.SetActive(false);

            }
        }
        updateSongData();
    }


    public void Play()
    {
        setSongData();
        audioSource.Play();
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        
    }

    public void Pause()
    {
        audioSource.Pause();
        pauseButton.SetActive(false);
        playButton.SetActive(true);
    }

    public void UnPause()
    {
        audioSource.UnPause();
    }

    /// <summary>
    /// set a time of new song name of singer,song 
    /// </summary>
    private void setSongData() {

        nameOfSong.text = audioSource.clip.name;
        step = 1 / audioSource.clip.length;   // step to move a pointer during the song
        totalTimeObject.text = convertToTimeFormat((int)audioSource.clip.length); ;
    }

    private void updateSongData() {

        timeScaler.value += Time.deltaTime * step;
        string currentTime = convertToTimeFormat((int)audioSource.time);
        currentTimeObject.text = currentTime;
    }

    /// <summary>
    /// convert time(int) that given in total number of seconds to string format(mm:ss)
    /// </summary>
    private string convertToTimeFormat(int time) {

        int min = time / 60;   // time (full minutes)
        int sec = time % 60;   //  time (unfull minutes left in seconds)
        string timeFormat = "";

        if (min < 10)
        {
            timeFormat += "0" + min.ToString();
        }
        else {
            timeFormat+= min.ToString();
        }

        timeFormat += ":";

        if (sec < 10)
        {
            timeFormat += "0" + sec.ToString();
        }
        else
        {
            timeFormat += sec.ToString();
        }

        return timeFormat;
    }
}
