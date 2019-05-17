using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleTextBoxManager : MonoBehaviour {

    public Text textBox;
    public float timeToLive = 0f;

	// Use this for initialization
	void Start () {
       // textBox.gameObject.SetActive(false);		
	}
	   
    // Update is called once per frame
    void Update () {
        if(timeToLive>=0){    
            timeToLive -= Time.deltaTime;  
        } else {
            textBox.text = "";         
        }    
    }

    public void UpdateTextBox(string _message){
        textBox.text = _message;
        timeToLive = 3f;
        Debug.Log(_message);
    }
}
