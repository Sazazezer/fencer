using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public float enemyHealth = 50f;
    public float maxEnemyHealth = 100f;
    public float touchDamage = 2f;

	// Use this for initialization
	void Start () {
		Debug.Log(touchDamage);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
