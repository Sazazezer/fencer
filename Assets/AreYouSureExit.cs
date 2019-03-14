using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.IO;

public class AreYouSureExit : MonoBehaviour {

    public GameObject areYouSureExit;
    public GameObject oldButtons;
    public GameObject exitGame;


    protected EventSystem eventSystem{
        get { return GameObject.Find ("EventSystem").GetComponent<EventSystem> (); }
    }

    public void No(){
        areYouSureExit.gameObject.SetActive(false);
        oldButtons.gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject (exitGame); 
    }

    public void Yes(){
        Application.Quit();
    }

}
