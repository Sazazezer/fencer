using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReady : EnemyState {


    public GameObject player;
    public Directions directions;
    [SerializeField]
    private float maxDistanceFromPlayer = 10f;
    private Rigidbody2D body2D;
    float speed = 20f;
    private float shiftSpar = 0f;
    private float rangeSpar = 0f;
    private EnemyAttack enemyAttack;
    private EnemyParry enemyParry;

	// Use this for initialization
	void Awake () {
		body2D = GetComponent<Rigidbody2D> ();
        enemyAttack = GetComponent<EnemyAttack> ();
        enemyParry = GetComponent<EnemyParry> ();

	}
	
	// Update is called once per frame
	public void OnReady () {
            FacePlayer();
            SparPlayer();
            //enemyAttack.Attack();
            //enemyParry.Parry();
	}

    void FacePlayer(){
        if (player.transform.position.x < transform.position.x){
            directions = Directions.Left;
        } else {
            directions = Directions.Right;
        }

        transform.localScale = new Vector3((float)directions, 1, 1);
    }

    void SparPlayer(){
     //   Debug.Log("Moving to kill");
        shiftSpar-=Time.deltaTime;
         Vector2 enemyVelocity = new Vector2((transform.position.x - player.transform.position.x + rangeSpar) * speed, body2D.velocity.y);
         body2D.velocity = -enemyVelocity.normalized * speed;

         if (shiftSpar<=0){
            Debug.Log("Change");
            shiftSpar = Random.Range(1,5);
            if (transform.position.x > player.transform.position.x){
                rangeSpar = Random.Range(-5,-40);
            }
            if (transform.position.x < player.transform.position.x){
                rangeSpar = Random.Range(5,40);
            }
         }
    }

    void AttackPlayer(){

    }

    void ParryPlayer(){

    }

    void GetParried(){

    }

    void UseItem(){

    }

}
