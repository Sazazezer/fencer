using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.IO;

public class Options : MonoBehaviour {

    public GameObject optionsMenu;
    public GameObject selectNormal;
    public GameObject oldButtons;
    public GameObject optionsButton;

    protected EventSystem eventSystem{
        get { return GameObject.Find ("EventSystem").GetComponent<EventSystem> (); }
    }

    public void OptionsSelected(){
            optionsMenu.gameObject.SetActive(true);
            eventSystem.SetSelectedGameObject (selectNormal); 
        }

    void Update(){
        if(Input.GetButtonUp("Cancel")){
            optionsMenu.gameObject.SetActive(false);
            oldButtons.gameObject.SetActive(true);
            eventSystem.SetSelectedGameObject (optionsButton); 

        }
    }
}

