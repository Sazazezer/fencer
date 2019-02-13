using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlStartUp : MonoBehaviour {

    public GameObject audioManagerPrefab;

	// Use this for initialization
	void Start () {
		if (!GameObject.FindGameObjectWithTag("AudioManager")){
            var audioManager = Instantiate(audioManagerPrefab);
            audioManager.name = audioManagerPrefab.name;
            DontDestroyOnLoad(audioManager);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
