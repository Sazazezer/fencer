using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : AbstractBehaviour {

	public float speed = 50f;
	public float climbMultiplier = 2f;
	public bool climbing;
	public bool wallCheck;

	// Use this for initialization
	void Start () {
		wallCheck = GetComponent<StickToWall>().onWallDetected;
	}
	
	// Update is called once per frame
	void Update () {

		if (wallCheck){
			climbing = true;
			var up = inputState.GetButtonValue (inputButtons [0]);
			var down = inputState.GetButtonValue (inputButtons [1]);
			var rush = inputState.GetButtonValue (inputButtons [2]);

			if (up || down){

				var tmpSpeed = speed;

				if(rush && climbMultiplier > 0){
					tmpSpeed *= climbMultiplier;
					climbing = true;
				}
				var velY = tmpSpeed * (float)inputState.direction;
				Debug.Log(inputState.direction);
				body2d.velocity = new Vector2(body2d.velocity.x,velY);			
			}
		}
	}
}
