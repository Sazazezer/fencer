using UnityEngine;
using System.Collections;

public class LookForward : MonoBehaviour {

	public Transform sightStart, sightEnd;
	public string layer = "Solid";
	public bool needsCollision = true;
    private EnemyBehaviour enemyBehaviour;

	private bool collision;

    void Awake () {
        enemyBehaviour = GetComponent<EnemyBehaviour>();
    }
	
	// Update is called once per frame
	void Update () {

        if(enemyBehaviour.states == States.Walk ||enemyBehaviour.states == States.Fly){

    		collision = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer (layer));

    		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);

    		if (collision == needsCollision) {
    			transform.localScale = new Vector3 (transform.localScale.x == 1 ? -1 : 1, 1, 1);
    		}
        }

	}
}
