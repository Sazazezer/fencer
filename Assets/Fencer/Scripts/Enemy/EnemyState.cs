using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour {
    
    public MonoBehaviour[] disableScripts;
    protected Rigidbody2D body2d;
    protected CollisionState collisionState;

    protected virtual void Awake(){
        body2d = GetComponent<Rigidbody2D>();
        collisionState = GetComponent<CollisionState>();
    }

	
	// Update is called once per frame
	void Update () {
		
	}



    protected virtual void ToggleScripts(bool value){
        foreach(var script in disableScripts){
            script.enabled = value;
        }
    }
}
