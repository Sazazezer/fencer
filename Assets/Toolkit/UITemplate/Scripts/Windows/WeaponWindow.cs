using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class WeaponWindow : GenericWindow {

	public ToggleGroup weaponGroup;

	public float inputDelay = .3f;

	private float delay = 0;
    private string weaponChoice;
	public int weapon{
		get {
			var total = weaponGroup.transform.childCount;

			for (var i = 0; i < total ; i++){
				var toggle = weaponGroup.transform.GetChild(i).GetComponent<Toggle>();
				if(toggle.isOn)
				return i;
			}
			return 0;
		}
		set{
			value = (int)Mathf.Repeat(value,weaponGroup.transform.childCount);

			var currentSelection = weaponGroup.ActiveToggles().FirstOrDefault();

			if(currentSelection != null){
				currentSelection.isOn = false;
			}
			
			currentSelection = weaponGroup.gameObject.transform.GetChild(value).GetComponent<Toggle>();
			currentSelection.isOn = true;

            weaponChoice = weaponGroup.gameObject.transform.GetChild(value).GetComponent<Toggle>().GetComponentInChildren<Text>().text;
			Debug.Log("Weapon " + value);
		}
	}

	public override void Open(){

		weapon = PlayerPrefs.GetInt("Weapon", 0 );
		base.Open();
	}

	// Use this for initialization
	public void OnSelect () {
		OnNextWindow();
		PlayerPrefs.SetString("Weapon", weaponChoice);
		
	}
	
	// Update is called once per frame
	void Update () {
delay += Time.deltaTime;

if(delay > inputDelay){

	var newWeapon = weapon;

	var hDir = Input.GetAxis("Vertical");

	if(hDir > 0){
		newWeapon--;
	} else if (hDir < 0) {
		newWeapon++;
			}

			if (newWeapon != weapon){
				weapon = newWeapon;
			}

			delay = 0;
}

		if(Input.GetButtonDown("Fire1")){
			OnSelect();
		}
	}
}
