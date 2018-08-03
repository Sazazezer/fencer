using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyRank{
    Civilian,
    Soldier,
    Boss
}

public enum States{
    Idle,
    Walk,
    Ready,
    Attack,
    Dead,
    Fall,
    Searching,
    Fly
}

public enum Tactics{
    Close,
    Medium,
    Long,
    Flight
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
    private EnemyFly enemyFly;
    private EnemyReady enemyReady;
    private float detectTimer = 1f;
    public GameObject weaponPrefab;
    public Tactics tactics;
    public EnemyRank enemyRank;
    public GameObject player;
    
    [SerializeField]
    Transform lineOfSightEnd;
    public bool playerInRange;
 
    protected virtual void Awake(){
        body2d = GetComponent<Rigidbody2D>();
        collisionState = GetComponent<CollisionState>();
        enemyDeath = GetComponent<EnemyDeath>();
        enemyFly = GetComponent<EnemyFly>();
        moveForward = GetComponent<MoveForward>();
        enemyReady = GetComponent<EnemyReady>();
        playerInRange = false;
    }

    void FixedUpdate(){
        absVelX = Mathf.Abs(body2d.velocity.x);
        absVelY = Mathf.Abs(body2d.velocity.y);
    }

    void EnemyIdle(){
        Debug.Log("I am Bone Idle");
        switch (tactics) {
            case Tactics.Flight: states = States.Fly; break;
            default: states = States.Walk; break;
        }
    }

    void EnemyWalk(){
        CheckFall();
     //   Debug.Log("I'm walking here");
//if(states == States.Walk){
            moveForward.OnWalk();
            DetectPlayer();
     //   }
    }

    void EnemyAttack(){
        Debug.Log("I'm your evil twin brother. HA!");
        //states = States.Dead;
    }

    void EnemyReady(){
       // CheckFall();
    //    Debug.Log("I see you. I kill you!");
        enemyReady.OnReady();
      
        DetectPlayer();
    }
    void EnemyDead(){
        Debug.Log("Oh no. Death. My one Weakness.");
      //  enemyDeath.OnExplode();
    }

    void EnemyFall(){
         Debug.Log("AAAAAAAAAAAAHHHHHHHHHHHHH");
         CheckFall();
    }

    void EnemySearching(){
       //  Debug.Log("Yar. Where be ye?");
         DetectPlayer();
    }

    void EnemyFly(){
         Debug.Log("WHHHHEEEEEE");
         enemyFly.OnFly();
    }

    public void CheckFall(){ 
        if(tactics != Tactics.Flight){
                if (absVelY > 0) {
                    states = States.Fall;
                }
                if (absVelY <= 0){//&& states != States.Searching) {
                    states = States.Walk;
                }
        }
    }

    public void DetectPlayer(){
        detectTimer -= Time.deltaTime;
        if (detectTimer <= 0){
            Vector2 directionToPlayer = player.transform.position - transform.position; // represents the direction from the enemy to the player    
            Debug.DrawLine(transform.position, player.transform.position, Color.magenta); // a line drawn in the Scene window equivalent to directionToPlayer
            
            Vector2 lineOfSight = lineOfSightEnd.transform.position - transform.position; // the centre of the enemy's field of view, the direction of looking directly ahead
            Debug.DrawLine(transform.position, lineOfSightEnd.transform.position, Color.yellow); // a line drawn in the Scene window equivalent to the enemy's field of view centre
            
            // calculate the angle formed between the player's position and the centre of the enemy's line of sight
            float angle = Vector2.Angle(directionToPlayer, lineOfSight);
         //   Debug.Log("Detecting");
            // if the player is within 65 degrees (either direction) of the enemy's centre of vision (i.e. within a 130 degree cone whose centre is directly ahead of the enemy) return true
            if (angle < 65 && !PlayerHiddenByObstacles() &&  states != States.Fall){
               states = States.Ready;
            }
            if (states == States.Ready ){
                if (angle > 65 || PlayerHiddenByObstacles()){
                    states = States.Searching;
                    detectTimer = 4f;
                }
            }
            if (states != States.Searching ){
                detectTimer = 1f;   
            }
        }      
    }

    bool PlayerHiddenByObstacles()
    {

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, player.transform.position - transform.position, distanceToPlayer);
        Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.blue); // draw line in the Scene window to show where the raycast is looking
        List<float> distances = new List<float>();
     
        foreach (RaycastHit2D hit in hits)
        {           
            // ignore the enemy's own colliders (and other enemies)
            if (hit.transform.tag == "Deadly")
                continue;
            
            // if anything other than the player is hit then it must be between the player and the enemy's eyes (since the player can only see as far as the player)
            if (hit.transform.tag != "Player")
            {
                return true;
            }
        }

        // if no objects were closer to the enemy than the player return false (player is not hidden by an object)
        return false; 

    }

    

    void Update(){
        switch(states) {
            case States.Idle: EnemyIdle(); break;
            case States.Walk: EnemyWalk(); break;
            case States.Attack: EnemyAttack(); break;
            case States.Ready: EnemyReady(); break;
            case States.Searching: EnemySearching(); break;
            case States.Dead: EnemyDead(); break;
            case States.Fall: EnemyFall(); break;
            case States.Fly: EnemyFly(); break;
        }
    }

 /*   protected virtual void ToggleScripts(bool value){
        foreach(var script in disableScripts){
            script.enabled = value;
        }
    }*/
}
