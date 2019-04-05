using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MotiveWindow : GenericWindow {

	public ToggleGroup motiveGroup;

	public float inputDelay = .3f;

	private float delay = 0;
    private string motiveChoice;
	public int motive{
		get {
			var total = motiveGroup.transform.childCount;

			for (var i = 0; i < total ; i++){
				var toggle = motiveGroup.transform.GetChild(i).GetComponent<Toggle>();
				if(toggle.isOn)
				return i;
			}
			return 0;
		}
		set{
			value = (int)Mathf.Repeat(value,motiveGroup.transform.childCount);

			var currentSelection = motiveGroup.ActiveToggles().FirstOrDefault();

			if(currentSelection != null){
				currentSelection.isOn = false;
			}
			
			currentSelection = motiveGroup.gameObject.transform.GetChild(value).GetComponent<Toggle>();
			currentSelection.isOn = true;

            motiveChoice = motiveGroup.gameObject.transform.GetChild(value).GetComponent<Toggle>().GetComponentInChildren<Text>().text;
			Debug.Log("Motive " + value);
		}
	}

	public override void Open(){

		motive = PlayerPrefs.GetInt("Motive", 0 );
		base.Open();
	}

	// Use this for initialization
	public void OnSelect () {
        PlayerPrefs.SetString("Motive", motiveChoice);
        Debug.Log("Woop" + PlayerPrefs.GetString("Motive"));
		OnNextWindow();

		
	}
	
	// Update is called once per frame
	void Update () {
delay += Time.deltaTime;

if(delay > inputDelay){

	var newMotive = motive;

	var hDir = Input.GetAxis("Vertical");

	if(hDir > 0){
		newMotive--;
	} else if (hDir < 0) {
		newMotive++;
			}

			if (newMotive != motive){
				motive = newMotive;
			}

			delay = 0;
}

		if(Input.GetButtonDown("Fire1")){
			OnSelect();
		}
	}
}
