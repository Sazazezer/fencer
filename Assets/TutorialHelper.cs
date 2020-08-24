using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHelper : MonoBehaviour {

    public string tutorialMessage;
    public bool messageShown = false;
    public string playerPrefsString;
    public int disableMessage = 0;

    void Start(){
    	disableMessage = PlayerPrefs.GetInt(playerPrefsString, 0);
    	if (disableMessage == 1){
    		messageShown = true;
    	}
    }

    void OnTriggerEnter2D(Collider2D other){
        if(messageShown == false){
            FindObjectOfType<TextBoxManager>().UpdateTextBox(tutorialMessage);
            messageShown = true;
            PlayerPrefs.SetInt(playerPrefsString, 1);        
        }
    }
}
