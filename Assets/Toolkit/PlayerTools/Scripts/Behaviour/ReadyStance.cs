using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyStance : AbstractBehaviour {

    public bool ready;

    protected override void Awake(){
    base.Awake ();

}

    protected virtual void OnReady(bool value){
        ready = value;

        ToggleScripts (!ready);
    }
    // Update is called once per frame
    void Update () {
        var isReady = inputState.GetButtonValue (inputButtons[0]);
        if(isReady && collisionState.standing){
            OnReady(true);
        } else if (!isReady){
            OnReady(false);
        }
    }
}
