using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlStartUp : MonoBehaviour {

    public GameObject audioManagerPrefab;
    public GameObject effectsManagerPrefab;
    public int gameHasStarted = 0;
    public GameObject fadeCanvas;
    public GameObject fadePanelKill;

	// Use this for initialization
	void Start () {
		if (!GameObject.FindGameObjectWithTag("AudioManager")){
            var audioManager = Instantiate(audioManagerPrefab);
            audioManager.name = audioManagerPrefab.name;
            DontDestroyOnLoad(audioManager);
        }
        if (!GameObject.FindGameObjectWithTag("EffectsManager")){
            var effectsManager = Instantiate(effectsManagerPrefab);
            effectsManager.name = effectsManagerPrefab.name;
            DontDestroyOnLoad(effectsManager);
        }
        gameHasStarted = (PlayerPrefs.GetInt("GameHasStarted",0));
        if (gameHasStarted == 1){
            if(fadeCanvas != null){
                GameObject.FindObjectOfType<Fade>().FadeMe();   
            }
	    }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
