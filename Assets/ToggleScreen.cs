using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScreen : MonoBehaviour {

    public string buttonSelected;
    public Text toggleScreenSelected;
    public void ToggleScreenSelected(string _buttonSelected){
        buttonSelected = _buttonSelected;
        toggleScreenSelected.text = buttonSelected;
        SetToggleScreen(buttonSelected);
        Debug.Log(buttonSelected + "selected.");
        Debug.Log(Screen.fullScreen);
    }

    public void SetToggleScreen(string _speedGiven){
        switch(_speedGiven){
            case "fullscreen": Screen.fullScreen = true; break;
            case "windowed": Screen.fullScreen = false; break;
            default:Screen.fullScreen = false; break;
        }
    }
}
