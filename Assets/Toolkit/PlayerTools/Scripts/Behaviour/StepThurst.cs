using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepThurst : AbstractBehaviour {



    public float shootDelay = .5f;
    public GameObject swordPrefab;
    public Vector2 firePosition = Vector2.zero;
    public Color debugColor = Color.green;
    public float debugRadius = 3f;
    public bool thurst = false;
    private float timeElapsed = 0.15f;
    private ReadyStance readyStance;

    void Start(){
        readyStance = GetComponent<ReadyStance>();
    }

    
    // Update is called once per frame
    void Update () {
        if(swordPrefab != null && readyStance.ready){
            var canFire = inputState.GetButtonValue(inputButtons[0]);

            if(canFire /*&& timeElapsed > shootDelay*/){
                thurst = true;
                CreateProjectile(CalculateFirePosition());
                timeElapsed = 0.15f;//controls the pause at the end of the turst
            }

    
        }
        if(timeElapsed != 0){
            timeElapsed -= Time.deltaTime;
        }

        if (timeElapsed <= 0){
            thurst = false;
        }
    }

    Vector2 CalculateFirePosition(){
        var pos = firePosition;
        pos.x *= readyStance.currentDirection;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        return pos;
    }

    public void CreateProjectile(Vector2 pos){
        var clone = Instantiate(swordPrefab, pos, Quaternion.identity) as GameObject;
        //clone.transform.localScale = transform.localScale;
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
