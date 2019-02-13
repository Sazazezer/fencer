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
        var renderer = player.GetComponent<Renderer>();
        float playerHeight = renderer.bounds.size.x;
    }
	
	// Update is called once per frame
	void Update () {

        //if(this.transform.position.y <= player.transform.position.y +50/*+ (playerHeight/2f)*/) {//inputState.absVelY < 1) || Input.GetKey("down")){ //was zero originally, cures jumping bug
        if (Input.GetKey("down")){
           boxColl.isTrigger = true;
        } else {
            boxColl.isTrigger = false;            
        }
    }

    void OnTriggerExit2D(Collider2D coll){
       // boxColl.isTrigger = false;
    }
}