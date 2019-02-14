using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmWindowResultsText : MonoBehaviour {

    public Text text;
    private string murderer;
    private string weapon;
    private string motive;

	// Use this for initialization
	void Start () {
   }
	
	// Update is called once per frame
	void Update () {
        murderer = PlayerPrefs.GetString("Murderer");
        weapon = PlayerPrefs.GetString("Weapon");
        motive = PlayerPrefs.GetString("Motive");
        text.text = "So you're saying to murderer was " + murderer + ". That they did it with the " + weapon + ", and that they did it because of " + motive + ". Is that Correct?";
        Debug.Log("So you're saying to murderer was " + murderer + ". That they did it with the " + weapon + ", and that they did it because of " + motive + ". Is that Correct?");
	}
}
