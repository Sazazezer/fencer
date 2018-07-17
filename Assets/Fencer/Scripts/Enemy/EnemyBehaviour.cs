using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States{
    Idle,
    Walk,
    Attack,
    Dead,
    Fall
}

public class EnemyBehaviour : MonoBehaviour {

  //  public Buttons[] inputButtons;
    protected Rigidbody2D body2d;
    protected CollisionState collisionState;
    public Directions direction = Directions.Right;
    public States states = States.Idle;
    public float absVelX = 0f;
    public float absVelY = 0f;
    private EnemyDeath enemyDeath;
    private MoveForward moveForward;

 
    protected virtual void Awake(){
        body2d = GetComponent<Rigidbody2D>();
        collisionState = GetComponent<CollisionState>();
        enemyDeath = GetComponent<EnemyDeath>();
        moveForward = GetComponent<MoveForward>();

    }

    void FixedUpdate(){
        absVelX = Mathf.Abs(body2d.velocity.x);
        absVelY = Mathf.Abs(body2d.velocity.y);
    }

    void EnemyIdle(){
        Debug.Log("I am Bone Idle");
        CheckStatus();
    }

    void EnemyWalk(){
        Debug.Log("I'm walking here!");
        moveForward.OnWalk();
        CheckStatus();
    }

    void EnemyAttack(){
        Debug.Log("I'm your evil twin brother. HA!");
        states = States.Dead;
    }
    void EnemyDead(){
        Debug.Log("Oh no. Death. My one Weakness.");
        enemyDeath.OnExplode();
    }

    void EnemyFall(){
         Debug.Log("AAAAAAAAAAAAHHHHHHHHHHHHH");
         CheckStatus();
    }

    void CheckStatus(){
        if (absVelY > 2) {states = States.Fall;}
        if (absVelY < 2) {states = States.Walk;}
    }

    void Update(){
        switch(states) {
            case States.Idle: EnemyIdle(); break;
            case States.Walk: EnemyWalk(); break;
            case States.Attack: EnemyAttack(); break;
            case States.Dead: EnemyDead(); break;
            case States.Fall: EnemyFall(); break;
        }
    }

 /*   protected virtual void ToggleScripts(bool value){
        foreach(var script in disableScripts){
            script.enabled = value;
        }
    }*/
}
