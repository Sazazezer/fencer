using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parried : AbstractBehaviour {


    public bool isParried;
    private float timeElapsed = 0f;

    protected override void Awake(){
    base.Awake ();
}

     protected virtual void OnParried(bool value){
        ToggleScripts (!isParried);

    }


    
    // Update is called once per frame
    public void GetParried () {
        //var parriedTest = inputState.GetButtonValue(inputButtons[0]);
        Debug.Log("3Egads. ou are skilled");
        if (collisionState.standing  && !isParried){
            isParried = true;
            timeElapsed = 1.5f;
            OnParried(true);
        } 
    }

    void Update(){

        if(timeElapsed != 0){
            timeElapsed -= Time.deltaTime;
        }

        if (timeElapsed <= 0){
            isParried = false;
            OnParried(false);
        }
    }
}
