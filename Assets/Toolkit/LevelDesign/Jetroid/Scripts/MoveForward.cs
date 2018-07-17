using UnityEngine;
using System.Collections;

public class MoveForward : EnemyState {

	public float speed = 10f;

	private Rigidbody2D body2D;

	// Use this for initialization
	void Start () {
		body2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	public void OnWalk () {
		body2D.velocity = new Vector2 (transform.localScale.x * speed, body2D.velocity.y) ;
	}
}
