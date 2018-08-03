using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActivation : AbstractBehaviour {

    public bool characterIsActive = false;
    public GameObject character;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(characterIsActive==false){
            Debug.Log("Spots on");
            ToggleScripts(false);
        } else {
             ToggleScripts(true);
             Debug.Log("Spots off");
        }
		
	}
}
