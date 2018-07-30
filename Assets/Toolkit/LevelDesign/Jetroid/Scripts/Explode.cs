using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	public Debris debris;
	public int totalDebris = 10;

    public GameObject character;

	// Use this for initialization
	void Start () {
	
	//	gameOver = gameObject.GetComponent<GameOver>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Deadly") {
			OnDamage (target.gameObject.GetComponent<Stats>().touchDamage);
		}
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Deadly") {
			OnDamage (target.gameObject.GetComponent<Stats>().touchDamage);
		}
	}

    public void OnDamage(float damage){
            character.GetComponent<Stats>().DecreaseHealth(damage); //abstraction needed
    }

	public void OnExplode(){

		var t = transform;

		for (int i = 0; i < totalDebris; i++) {

			t.TransformPoint (0, -100, 0);
			var clone = Instantiate (debris, t.position, Quaternion.identity) as Debris;
			var body2D = clone.GetComponent<Rigidbody2D> ();
			body2D.AddForce (Vector3.right * Random.Range (-1000, 1000));
			body2D.AddForce (Vector3.up * Random.Range (500, 2000));
		}
		//GameObject gameControls = GameObject.Find("GameControls");
		//GameOver gameOver = gameControls.GetComponent<GameOver>();
		
        if(transform.gameObject.tag == "Player"){
            GameOver.playerDead = true;
        }
		Destroy (gameObject);

	}
}
