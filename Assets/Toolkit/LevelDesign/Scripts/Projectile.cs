using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	void OnDestroy(){
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D target){
		OnDestroy ();
	}
}
