using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Example;

public class TalkOptions : AbstractBehaviour {

		
		private Talk talk;

    void Start(){

		talk = gameObject.GetComponent<Talk>();
	
	}
	
	// Update is called once per frame
	void Update () {


		if(talk.toggleOptions == true && talk.choicesGiven == true){
			
			var optOne = inputState.GetButtonValue (inputButtons[0]);
			var optTwo = inputState.GetButtonValue (inputButtons[1]);
			var optThree = inputState.GetButtonValue (inputButtons[2]);
			var optFour = inputState.GetButtonValue (inputButtons[3]);
		            

		    if (optOne) {
                FindObjectOfType<ExampleDialogueUI> ().SetOption(0);
            }
            if (optTwo) {          	
                FindObjectOfType<ExampleDialogueUI> ().SetOption(1);                        
            }
            if (optThree) {        
                FindObjectOfType<ExampleDialogueUI> ().SetOption(2);                   
            }
            if (optFour) {      
                FindObjectOfType<ExampleDialogueUI> ().SetOption(3);                     
            }

      	}
	}
}
