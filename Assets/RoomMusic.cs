using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMusic : MonoBehaviour {

    public AudioClip[] roomMusic;

	// Use this for initialization
	void Start () {

        if(GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>().clip != roomMusic[0]){
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>().clip = roomMusic[0];            
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>().Play();
        }

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
