using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSpeed : MonoBehaviour {

    public string buttonSelected;
    public Text speedTextSelected;

    public void TextSpeedSelected(string _buttonSelected){
        buttonSelected = _buttonSelected;
        speedTextSelected.text = buttonSelected;
        SetTextSpeed(buttonSelected);
        Debug.Log(buttonSelected + "selected.");
        Debug.Log(PlayerPrefs.GetFloat("TextSpeed", 0.025f));
    }

    public void SetTextSpeed(string _speedGiven){
        switch(_speedGiven){
            case "slow": PlayerPrefs.SetFloat("TextSpeed", 0.1F); break;
            case "normal": PlayerPrefs.SetFloat("TextSpeed", 0.025F); break;
            case "fast": PlayerPrefs.SetFloat("TextSpeed", 0.05F); break;
            default:PlayerPrefs.SetFloat("TextSpeed", 0.025F); break;
        }
    }
}
