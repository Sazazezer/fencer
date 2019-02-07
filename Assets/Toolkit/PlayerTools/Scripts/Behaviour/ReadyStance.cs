using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyStance : AbstractBehaviour {

    public bool ready;
    public bool freezeDirection = false;
    public int currentDirection;
    private bool disableStance = true; //remove this to reactivate stance ability

    protected override void Awake(){
    base.Awake ();

}

    protected virtual void OnReady(bool value){
        ready = value;

        ToggleScripts (!ready);

        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);

        if(right){
            inputState.direction = Directions.Right;   
        } else if (left) {
            inputState.direction = Directions.Left;

        }
    }

    
    // Update is called once per frame
    void Update () {
        var isReady = inputState.GetButtonValue (inputButtons[2]);
        if(isReady && collisionState.standing && disableStance == false){
            OnReady(true);
            if (!freezeDirection){
                if(inputState.direction == Directions.Left){
                    currentDirection = -1;
                }
                if(inputState.direction == Directions.Right){
                    currentDirection = 1;
                }
                freezeDirection = true;
            }

        } else if (!isReady){
            OnReady(false);
            freezeDirection = false;
        }
    }
}
