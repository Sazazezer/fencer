using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbables : AbstractBehaviour {

    public float speed;
    private Rigidbody2D rb;
    private float inputHorizontal;
    private float inputVertical;
    public float distance;
    public LayerMask whatIsLadder;
    public bool isClimbing;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if(hitInfo.collider != null){
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                isClimbing = true;
            }
        } else {
            isClimbing = false;
        }
		
        if(isClimbing == true){
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
            rb.gravityScale = 0;
        } else {
            rb.gravityScale = 40;
        }
	}
}
