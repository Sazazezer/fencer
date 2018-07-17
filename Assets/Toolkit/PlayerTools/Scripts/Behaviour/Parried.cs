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
    void Update () {
        var parriedTest = inputState.GetButtonValue(inputButtons[0]);

        if(parriedTest && collisionState.standing  && !isParried){
            isParried = true;
            timeElapsed = 1.5f;
            OnParried(true);
        } 

        if(timeElapsed != 0){
            timeElapsed -= Time.deltaTime;
        }

        if (timeElapsed <= 0){
            isParried = false;
            OnParried(false);
        }
    }
}
