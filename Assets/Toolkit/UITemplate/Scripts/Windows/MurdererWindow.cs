using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MurdererWindow : GenericWindow {

	public ToggleGroup murdererGroup;

	public float inputDelay = .3f;

	private float delay = 0;
    private string murdererChoice;
	public int murderer{
		get {
			var total = murdererGroup.transform.childCount;

			for (var i = 0; i < total ; i++){
				var toggle = murdererGroup.transform.GetChild(i).GetComponent<Toggle>();
				if(toggle.isOn)
				return i;
			}
			return 0;
		}
		set{
			value = (int)Mathf.Repeat(value,murdererGroup.transform.childCount);

			var currentSelection = murdererGroup.ActiveToggles().FirstOrDefault();

			if(currentSelection != null){
				currentSelection.isOn = false;
			}
			
			currentSelection = murdererGroup.gameObject.transform.GetChild(value).GetComponent<Toggle>();
			currentSelection.isOn = true;

            murdererChoice = murdererGroup.gameObject.transform.GetChild(value).GetComponent<Toggle>().GetComponentInChildren<Text>().text;
			Debug.Log("Murderer " + value);
		}
	}

	public override void Open(){

		murderer = PlayerPrefs.GetInt("Murderer");
		base.Open();
	}

	// Use this for initialization
	public void OnSelect () {
        Debug.Log("Boope");
		OnNextWindow();
        Debug.Log("Baope");
		PlayerPrefs.SetString("Murderer", murdererChoice);
		
	}
	
	// Update is called once per frame
	void Update () {
delay += Time.deltaTime;

if(delay > inputDelay){

	var newMurderer = murderer;

	var hDir = Input.GetAxis("Vertical");

	if(hDir > 0){
		newMurderer--;
	} else if (hDir < 0) {
		newMurderer++;
			}

			if (newMurderer != murderer){
				murderer = newMurderer;
			}

			delay = 0;
}

		if(Input.GetButtonDown("Fire1")){
			OnSelect();
		}
	}
}
