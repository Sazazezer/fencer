using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMusic : MonoBehaviour {

    public AudioClip[] roomMusic;
    public AudioClip[] roomAmbience;

	// Use this for initialization
	void Start () {
		Debug.Log(GameObject.FindGameObjectWithTag("AudioManager"));
        if(GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>().clip != roomMusic[0]){
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>().clip = roomMusic[0];
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("GameVolume",0.5f);         
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>().Play();
        }

        if(GameObject.FindGameObjectWithTag("EffectsManager").GetComponent<AudioSource>().clip != roomAmbience[0]){
            GameObject.FindGameObjectWithTag("EffectsManager").GetComponent<AudioSource>().clip = roomAmbience[0];
            GameObject.FindGameObjectWithTag("EffectsManager").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("GameVolume",0.5f);         
            GameObject.FindGameObjectWithTag("EffectsManager").GetComponent<AudioSource>().Play();
        }

		
	}
	
	// Update is called once per frame
	void Update () {

		if (!GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>().isPlaying)
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>().clip = roomMusic[Random.Range(0,3)];
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>().Play();
            Debug.Log("Switching");
        }
		
	}
}
