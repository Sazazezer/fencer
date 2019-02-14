using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.IO;

public class ChoicesNo : MonoBehaviour {

    public GameObject areYouSure;
    public GameObject oldButtons;
    public GameObject newGame;


    protected EventSystem eventSystem{
        get { return GameObject.Find ("EventSystem").GetComponent<EventSystem> (); }
    }

    public void No(){
        GameObject.Find("ConfirmWindow").GetComponent<StartWindow>().OnNextWindow();
    }



}
