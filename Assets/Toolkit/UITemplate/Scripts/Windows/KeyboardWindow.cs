using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyboardWindow : GenericWindow {

	public Text inputField;
	public int maxCharacters = 7;

	private float delay = 0;
	private float cursorDelay = .5f;
	private bool blink;

private string _text = "";

	void Update(){
		var text = _text;

		if(_text.Length < maxCharacters){

			text += "_";
		}

		if (blink){
			text = text.Remove (text.Length - 1);
		}

		inputField.text = text;

		delay += Time.deltaTime;

		if(delay > cursorDelay){
			delay = 0;
			blink = !blink;
		}
	}

	public void OnKeyPress(string key){
		if(_text.Length < maxCharacters){
			_text += key;
		}
	}

	public void OnDelete(){
		if(_text.Length > 0){
			_text = _text.Remove (_text.Length - 1);
		}
	}

	public void OnAccept(){
		//OnNextWindow();
        SceneManager.LoadScene(sceneName:"TestScene"); //this is going to need a system...
	}

	public void OnCancel(){
		OnPreviousWindow();
	}
}
