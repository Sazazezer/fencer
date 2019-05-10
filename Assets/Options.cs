using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.IO;

public class Options : MonoBehaviour {

    public GameObject optionsMenu;
    public GameObject selectSlow;
    public GameObject selectNormal;
    public GameObject selectFast;
    public GameObject selectSpeed;
    public GameObject oldButtons;
    public GameObject optionsButton;
    public float currentSpeed = 0.025f;

    public void Start(){
            GetCurrentSpeed();
    }

    protected EventSystem eventSystem{
        get { return GameObject.Find ("EventSystem").GetComponent<EventSystem> (); }
    }

    public void OptionsSelected(){
            GetCurrentSpeed();
            Debug.Log("options presso");;
            Debug.Log(selectSpeed);
            optionsMenu.gameObject.SetActive(true);
            eventSystem.SetSelectedGameObject (selectSpeed); 
        }

    void Update(){
        if(Input.GetButtonUp("Jump") || Input.GetButtonUp("Cancel")){
            CancelOptionsScreen();
        }
    }

    public void CancelOptionsScreen(){
        optionsMenu.gameObject.SetActive(false);
        oldButtons.gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject (optionsButton);         
    }

    public void GetCurrentSpeed(){
        currentSpeed = PlayerPrefs.GetFloat("TextSpeed", 0.025F);

        if (currentSpeed == 0.1f){
                selectSpeed = selectSlow;
            } else if (currentSpeed == 0.025f){
                    selectSpeed = selectNormal;
                } else if (currentSpeed == 0.05f){
                    selectSpeed = selectFast;
                }        
    }
}

