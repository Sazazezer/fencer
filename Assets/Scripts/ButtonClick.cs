using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {

    public int index;
    public string content;
    public string journal;

	// Use this for initialization
	public void SendToJournalTextPanel () {
		GameObject.Find("JournalText").GetComponent<Text>().text = journal;
       // GameObject.Find("JournalHeader").GetComponent<Text>().text = content;
	}
}
