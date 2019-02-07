using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIAccess : MonoBehaviour {

    private PlayerUIManager playerUIManager;
    public bool UIAccessRestricted = false;

	// Use this for initialization
	void Start () {
		playerUIManager = GetComponent<PlayerUIManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (UIAccessRestricted==false){
            if (Input.GetButtonDown("Fire2")){
                    playerUIManager.GoToJournal();                    
            }

            if (Input.GetButtonDown("Fire3")){
                    playerUIManager.GoToBag();            
            }
            if (Input.GetButtonDown("Cancel")){
                playerUIManager.BackToGame();
            }

            //ultimate save,load,reset area
            //save
            if (Input.GetKeyDown(KeyCode.F9)){
                playerUIManager.SaveGameData();
            }
            //load
            if (Input.GetKeyDown(KeyCode.F10)){
                playerUIManager.LoadGameData();
            }
            //reset
            if (Input.GetKeyDown(KeyCode.F12)){
                playerUIManager.ResetGameData();
            }
                }
        }

    public void switchRestrictionToTrue(){
            UIAccessRestricted = true;
            Debug.Log("Set to True");
    }
	
    public void switchRestrictionToFalse(){
            UIAccessRestricted = false;
            Debug.Log("Set to False");
    }
	}

