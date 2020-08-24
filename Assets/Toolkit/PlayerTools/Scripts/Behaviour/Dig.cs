using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dig : AbstractBehaviour {




    public bool digging = false;


    void Start(){
    }

    
    // Update is called once per frame
    void Update () {
        if(digging){
            ToggleScripts(false);
        }
    }

}
