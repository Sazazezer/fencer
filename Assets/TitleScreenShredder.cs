using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenShredder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(GameObject.Find("DialogueStorage")){
            Destroy(GameObject.Find("DialogueStorage"));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
