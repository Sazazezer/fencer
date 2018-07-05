using UnityEngine;
using System.Collections;

public class AlienC : MonoBehaviour {

	public float attackDelay = 3f;
	public GameObject projectile;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();

		if (attackDelay != 0) {
			StartCoroutine (OnAttack ());
		}
	}

	IEnumerator OnAttack(){
		yield return new WaitForSeconds (attackDelay);

		Fire ();
		StartCoroutine (OnAttack ());
	}

	void Fire(){
		animator.SetInteger ("AnimState", 1);
	}

	// Update is called once per frame
	void Update () {
		animator.SetInteger ("AnimState", 0);
	}

	void OnFire(){
		if (projectile != null) {
		//	var clone = Instantiate (projectile, transform.position, Quaternion.identity);
		}
	}
}
