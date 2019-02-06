using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueVariableChecker : MonoBehaviour {

    public string uniqueVariable = "";
    public int uniqueVariablesCurrentValue = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (this.GetComponent<DoorLock>().locked == false){
            GameObject.Find("GameControls").GetComponent<UniqueVariablesList>().SetUniqueVariable(uniqueVariable,1);
            uniqueVariablesCurrentValue = 1;
        }
		
	}
}
