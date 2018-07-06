using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	private InputState inputState;
	private Walk walkBehaviour;
	private Animator animator;
	private CollisionState collisionState;
	private Duck duckBehaviour;
    private ReadyStance readyStance;
    private StepThurst stepThurst;
    private Parry parry;

	void Awake(){
		inputState = GetComponent<InputState>();
		walkBehaviour = GetComponent<Walk>();
		animator = GetComponent<Animator>();
		collisionState = GetComponent<CollisionState>();
		duckBehaviour = GetComponent<Duck>();
        readyStance = GetComponent<ReadyStance>();
        stepThurst = GetComponent<StepThurst>();
        parry = GetComponent<Parry>();
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(collisionState.standing ){
			ChangeAnimationState(0);
		}
		if(inputState.absVelX > 0 ){
			ChangeAnimationState(1);
		}

		if(inputState.absVelY > 1){ //was zero originally, cures jumping bug
			ChangeAnimationState(2);
		}

		animator.speed = walkBehaviour.running ? walkBehaviour.runMultiplier : 1;

		if (duckBehaviour.ducking){
			ChangeAnimationState(3);
		}

		if(!collisionState.standing && collisionState.onWall){
			ChangeAnimationState(4);
		}

        if(readyStance.ready){
            ChangeAnimationState(5);
        }

        if(stepThurst.thurst){
            ChangeAnimationState(6);
        }

        if(parry.parrying){
            ChangeAnimationState(7);
        }
	}

	void ChangeAnimationState(int value){
		animator.SetInteger("AnimState", value);
	}
}
