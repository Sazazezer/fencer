﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : AbstractBehaviour {

	public float jumpSpeed = 200f;
	public float jumpDelay = .1f; //.1f
	public int jumpCount = 0; //2 remeber to check the instance!
	public GameObject dustEffectPrefab;

	protected float lastJumpTime = 0;
	protected int jumpsRemaining = 0;
    public bool isJumping;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		var canJump = inputState.GetButtonValue (inputButtons [0]);
		var holdTime = inputState.GetButtonHoldTime(inputButtons [0]);
			if (collisionState.standing){
				if(canJump && holdTime < .1f){
					jumpsRemaining = jumpCount -1;
					OnJump();
				}
			} else {
				if(canJump && holdTime < .1f && Time.time - lastJumpTime > jumpDelay){

					if(jumpsRemaining > 0){
					jumpsRemaining = jumpCount -1;
					OnJump();
					jumpsRemaining--;
					var clone = Instantiate(dustEffectPrefab);
					clone.transform.position = transform.position;
				}
				}
			}

	}

	protected virtual void OnJump(){
			var vel = body2d.velocity;
			lastJumpTime = Time.time;
			body2d.velocity = new Vector2 (vel.x, jumpSpeed);
	}
}
