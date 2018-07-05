using UnityEngine;
using System.Collections;

public class SwordHitbox : MonoBehaviour {

	//public Vector2 initialVelocity = new Vector2(100, -100);
	public float timeUntilDeath = 10;
	//private Rigidbody2D body2d;

	// Use this for initialization
	void Awake () {
		//float timeUntilDeath = Time.deltaTime * 3;
	
		//var startVelX = initialVelocity.x * transform.localScale.x;

		//body2d.velocity = new Vector2 (startVelX, initialVelocity.y);

	}

	void OnCollisionEnter2D(Collision2D target){

	//	if (target.gameObject.transform.position.y < transform.position.y) {
		//	timeUntilDeath --;
	//	} I believe i'll need this for targeting enemies
	}

	void Update(){
		timeUntilDeath --;
		if (timeUntilDeath <= 0)
			Destroy (gameObject);
	}
}
