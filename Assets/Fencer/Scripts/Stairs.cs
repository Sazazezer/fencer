using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Stairs : MonoBehaviour {

    public GameObject player;
    private InputState inputState;
    BoxCollider2D boxColl;

	// Use this for initialization
void Awake () {
    boxColl = gameObject.GetComponent<BoxCollider2D> ();
    inputState = player.GetComponent<InputState>();
}
	
	// Update is called once per frame
	void Update () {
 
        if(inputState.absVelY > 1 || Input.GetKey("down")){ //was zero originally, cures jumping bug
            boxColl.isTrigger = true;
        }

    }

    void OnTriggerExit2D(Collider2D coll){
        boxColl.isTrigger = false;
    }

		
	
}