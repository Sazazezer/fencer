using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalCanvas : MonoBehaviour {

    public Canvas journal;
    public int panelSelected = 0;

	
    public void Activate(){
        journal.GetComponent<Canvas> ().enabled = true;    
        panelSelected = 0; //selected button panel  
    }

    public void Deactivate(){
        journal.GetComponent<Canvas> ().enabled = false;
    }
}
