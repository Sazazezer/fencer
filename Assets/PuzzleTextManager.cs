using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleTextManager : MonoBehaviour {

    public string messageBox;
    public Sprite newImage;
    public Button[] activateButtons;
    public Button[] deactivateButtons;
    public Button switchToButton;
   // public GameObject imagePanel;

    public void UpdateTextBox(){
        FindObjectOfType<PuzzleTextBoxManager>().UpdateTextBox(messageBox);

        if (newImage != null){
            Debug.Log(activateButtons.Length);
            GameObject.Find("PuzzleListPanel").GetComponent<Image>().sprite = newImage;
        }

        if (activateButtons.Length != 0){
            for(var i = 0; i < activateButtons.Length; i++){
                Debug.Log(i);
                activateButtons[i].gameObject.SetActive(true);            }
        }

        if (deactivateButtons.Length != 0){
            for(var i = 0; i < deactivateButtons.Length; i++){
                switchToButton.Select();
                deactivateButtons[i].gameObject.SetActive(false);
            }
        }
    }
}
