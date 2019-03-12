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

    protected EventSystem eventSystem{
        get { return GameObject.Find ("EventSystem").GetComponent<EventSystem> (); }
    }

    public void OptionsSelected(){
            optionsMenu.gameObject.SetActive(true);
            eventSystem.SetSelectedGameObject (selectNormal); 
        }
}

