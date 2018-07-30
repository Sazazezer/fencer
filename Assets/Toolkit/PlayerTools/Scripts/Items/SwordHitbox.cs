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
                if(transform.parent.gameObject.tag == enemyTag){
                    Debug.Log("Player parries enemy (yay)");
                   transform.parent.gameObject.GetComponent<EnemyParried>().GetParried(); //this version works
                    }
            }
        }

        if(target.gameObject.tag == playerTag || target.gameObject.tag == enemyTag){
            Debug.Log(target.gameObject);
            target.gameObject.GetComponent<Stats>().DecreaseHealth(10);
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
