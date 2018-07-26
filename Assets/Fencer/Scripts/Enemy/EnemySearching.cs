using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearching : EnemyState {

    public float searchTime = 10f;
    private EnemyBehaviour enemyBehaviour;

	// Use this for initialization
	void Awake () {
		enemyBehaviour = GetComponent<EnemyBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
        searchTime -=Time.deltaTime;
        if (searchTime<=0){
            Debug.Log("Bah, enough of this");
            searchTime = 10f;
            enemyBehaviour.states = States.Idle;
        }
		
	}
}
