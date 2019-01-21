using UnityEngine;
using System.Collections;

public class oldPlayerController : MonoBehaviour {

	public Vector2 moving = new Vector2 ();
	//public float jumpPower = 150f;
	//private Rigidbody2D body2D; //!!

	private Player player;
	// Use this for initialization
	void Start () {
	player= GetComponent<Player> ();	}
	
	// Update is called once per frame
	void Update () {
	
		moving.x = moving.y = 0;

		if (Input.GetKey ("right")) {
			moving.x = 1;
		} else if (Input.GetKey ("left")) {
			moving.x = -1;
		}

		if (Input.GetKeyDown ("up") && player.standing) {
				moving.y = 1;	
			//body2D.AddForce(Vector2.up * jumpPower);
		} 
		if (Input.GetKeyUp ("up")) {
			moving.y = 0;
		}
		/*if (!Input.GetKey ("up") && player.jumping) {
				moving.y = -1;
			}*/

	}
}
