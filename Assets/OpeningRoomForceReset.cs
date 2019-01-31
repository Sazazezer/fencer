using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningRoomForceReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find("Player").GetComponent<PlayerUIManager>().ResetGameData();
        Debug.Log("Game Data Reset");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
