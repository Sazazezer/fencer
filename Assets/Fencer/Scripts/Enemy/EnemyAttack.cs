using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyState {


    public float shootDelay = .5f;
    public float attackRange = 30f;
    public float attackRangeCheck;
    public Vector2 firePosition = Vector2.zero;
    public Color debugColor = Color.green;
    public float debugRadius = 3f;
    private float timeElapsed = 0f;
    public GameObject player;
    public float test;

    private EnemyReady enemyReady;

    void Awake(){
        enemyReady = GetComponent<EnemyReady>();
    }
    
    // Update is called once per frame
    public void Attack () {
        if(enemyBehaviour.weaponPrefab != null){
            attackRangeCheck = Vector3.Distance(player.transform.position, transform.position);
          //  test = attackRangeCheck < attackRange;
            if(attackRangeCheck < attackRange && timeElapsed > shootDelay){
                CreateProjectile(CalculateFirePosition());
                timeElapsed = 0;
            }

            timeElapsed += Time.deltaTime;
        }
    }

    Vector2 CalculateFirePosition(){
        var pos = firePosition;
        pos.x *= (int)enemyReady.directions;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        return pos;
    }

    public void CreateProjectile(Vector2 pos){
        var clone = Instantiate(enemyBehaviour.weaponPrefab, pos, Quaternion.identity) as GameObject;
        clone.GetComponent<SwordHitbox>().actionType = ActionType.Attacking;
        Debug.Log("Attack!");

    }

    void OnDrawGizmos(){
        Gizmos.color = debugColor;

        var pos = firePosition;
        pos.x *= (int)enemyReady.directions;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        Gizmos.DrawWireSphere(pos, debugRadius);
    }
}
