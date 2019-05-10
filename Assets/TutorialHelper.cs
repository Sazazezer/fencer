using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHelper : MonoBehaviour {

    public string tutorialMessage;
    public bool messageShown = false;

    void OnTriggerEnter2D(Collider2D other){
        if(messageShown == false){
            FindObjectOfType<TextBoxManager>().UpdateTextBox(tutorialMessage);
            messageShown = true;            
        }
    }
}
