﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongJump : Jump {

	public float longJumpDelay = .15f;
	public float longJumpMultiplier = 1.5f;
	public bool canLongJump;
	public bool isLongJumping;
    public AudioClip jumpSound;
    private float jumpVolume = 0.5f;

    private AudioSource source;

    void Start () {
        source = GetComponent<AudioSource>();
        jumpVolume = PlayerPrefs.GetFloat("GameSoundEffect",0.5f);

    }

	protected override void Update(){
		
		var canJump = inputState.GetButtonValue (inputButtons [0]);
		var holdTime = inputState.GetButtonHoldTime(inputButtons [0]);
		
		if(!canJump)
			canLongJump = false;

		if(collisionState.standing && isLongJumping)
			isLongJumping = false;

		base.Update();

		if(canLongJump && !collisionState.standing && holdTime > longJumpDelay){
			var vel = body2d.velocity;
			body2d.velocity = new Vector2(vel.x, jumpSpeed * longJumpMultiplier);
			canLongJump = false;
			isLongJumping = true;
		}
	}
	protected override void OnJump(){
		base.OnJump();
		canLongJump = true;
        if(!source.isPlaying && this.GetComponent<PlayerUIManager>().inJournal == false && this.GetComponent<PlayerUIManager>().inBag == false && this.GetComponent<PlayerUIManager>().inPuzzle == false){
        	if(jumpSound!=null){
            	source.PlayOneShot(jumpSound,jumpVolume);          		
        	}
          
        }

	}
}
