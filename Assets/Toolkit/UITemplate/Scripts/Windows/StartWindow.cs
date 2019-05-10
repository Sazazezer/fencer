using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartWindow : GenericWindow {

	public GameObject continueButton;
    public GameObject areYouSureExit;
    public int canContinue = 0;

    public void Start(){
        canContinue = PlayerPrefs.GetInt("ContinueButton",0);
        Debug.Log(canContinue);
        if (canContinue == 1) {
            continueButton.gameObject.SetActive (true);
            firstSelected = continueButton.gameObject;
            eventSystem.SetSelectedGameObject (firstSelected);
        }
    }

    public void Update(){
        if (Input.GetKeyDown("space")){
            PlayerPrefs.SetInt("ContinueButton",0);
        }
    }

	public override void Open ()
	{
		base.Open ();
	}

	public void NewGame(){
		OnNextWindow();
	}

	public void Continue(){
		Debug.Log ("Continue Pressed");
	}

	public void Options(){
		Debug.Log ("Options Pressed");
	}

    public void ExitGame(){
        Debug.Log ("Exit Pressed");
    }


}
