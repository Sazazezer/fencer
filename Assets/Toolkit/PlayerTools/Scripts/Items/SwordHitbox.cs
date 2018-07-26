using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ActionType{
    Attacking,
    Parrying,
}

public class SwordHitbox : MonoBehaviour {

    public ActionType actionType;
	public float timeUntilDeath = 10;
    private SpriteRenderer spr;
    public string targetTag = "PlayerWeapon";
    public string playerTag = "Player";
    public string enemyTag = "Deadly";

    void Start(){
       spr  = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.tag == targetTag){
            if(actionType == ActionType.Attacking && target.gameObject.GetComponent<SwordHitbox>().actionType == ActionType.Attacking){
                Debug.Log("Attack hits attack");
            }

            if(actionType == ActionType.Attacking && target.gameObject.GetComponent<SwordHitbox>().actionType == ActionType.Parrying){
                Debug.Log("Attack hits parry");
                if(transform.parent.gameObject.tag == playerTag){
                    Debug.Log("Enemy parries player");
                   transform.parent.gameObject.GetComponent<Parried>().GetParried(); //this version works
                    }
            }
            if(actionType == ActionType.Parrying && target.gameObject.GetComponent<SwordHitbox>().actionType == ActionType.Attacking){
              //  if(transform.parent.gameObject.tag == enemyTag){ //commented out while trying to fix target issue
                Debug.Log("Parry hits Attack");
                target.transform.parent.gameObject.GetComponent<EnemyParried>().GetParried();
              //  }
            }
        }
    }
	



	void Update(){

        switch (actionType){
            case ActionType.Attacking: spr.color = Color.yellow; break;
            case ActionType.Parrying: spr.color = Color.green; break;
        }

        
		timeUntilDeath --;
		if (timeUntilDeath <= 0)
			Destroy (gameObject);
	}
}
