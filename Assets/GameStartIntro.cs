﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class GameStartIntro : MonoBehaviour
{
    public GameObject fadeCanvas;
    public GameObject fadePanelKill;
    public AudioClip audio;
    private AudioSource audiosource;
    public int gameHasStarted = 0;


    void Start()
    {
        gameHasStarted = (PlayerPrefs.GetInt("GameHasStarted",0));

        if (gameHasStarted == 0){
            audiosource = GetComponent<AudioSource>();
            audiosource.clip = audio;
            audiosource.Play();
            StartCoroutine(WaitForSound(audio));
            PlayerPrefs.SetInt("GameHasStarted",1);
        } else {
            if(fadeCanvas != null){
                GameObject.FindObjectOfType<Fade>().FadeMe();   
            }
        }
    }

    public IEnumerator WaitForSound(AudioClip Sound)
    {
       yield return new WaitUntil(() => audiosource.isPlaying == false);
       // or yield return new WaitWhile(() => audiosource.isPlaying == true);
    if(fadeCanvas != null)
        GameObject.FindObjectOfType<Fade>().FadeMe();
    }
}

