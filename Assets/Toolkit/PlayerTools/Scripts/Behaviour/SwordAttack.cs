using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : AbstractBehaviour {

	public float shootDelay = .5f;
	public GameObject swordPrefab;
	public Vector2 firePosition = Vector2.zero;
	public Color debugColor = Color.green;
	public float debugRadius = 3f;
	private float timeElapsed = 0f;
    private ReadyStance readyStance;
    private bool disableSword = true; //remove this to reactivate sword

    void Start(){
        readyStance = GetComponent<ReadyStance>();
    }

	
	// Update is called once per frame
	void Update () {
		if(swordPrefab != null && disableSword == false){
			var canFire = inputState.GetButtonValue(inputButtons[0]);

			if(canFire && timeElapsed > shootDelay){
				CreateProjectile(CalculateFirePosition());
				timeElapsed = 0;
			}

			timeElapsed += Time.deltaTime;
		}
	}

	Vector2 CalculateFirePosition(){
		var pos = firePosition;
        if(readyStance.ready){
         /*   if(readyStance.currentDirection == 1){
                pos.x *= 1;
            } else if (readyStance.currentDirection == -1){
	       	    pos.x *= -1;
            }*/
             pos.x *= readyStance.currentDirection;
        } else {
            pos.x *= (float)inputState.direction;
        }
		pos.x += transform.position.x;
		pos.y += transform.position.y;

		return pos;
	}

	public void CreateProjectile(Vector2 pos){
		var clone = Instantiate(swordPrefab, pos, Quaternion.identity, transform) as GameObject;
		clone.GetComponent<SwordHitbox>().actionType = ActionType.Attacking;
       //  Debug.Log(clone.transform.parent.name);

	}

	void OnDrawGizmos(){
		Gizmos.color = debugColor;

		var pos = firePosition;
		if(inputState != null)
		pos.x *= (float)inputState.direction;
		pos.x += transform.position.x;
		pos.y += transform.position.y;

		Gizmos.DrawWireSphere(pos, debugRadius);
	}
}
