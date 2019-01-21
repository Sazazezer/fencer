using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalCanvas : MonoBehaviour {

    public Canvas journal;

	
    public void Activate(){
        journal.GetComponent<Canvas> ().enabled = true;        
    }

    public void Deactivate(){
        journal.GetComponent<Canvas> ().enabled = false;
    }
}
