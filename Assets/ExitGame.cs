using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.IO;

public class ExitGame : MonoBehaviour {

    public GameObject areYouSureExit;
    public GameObject selectNo;

    protected EventSystem eventSystem{
        get { return GameObject.Find ("EventSystem").GetComponent<EventSystem> (); }
    }

    public void ExitGameSelected(){
            areYouSureExit.gameObject.SetActive(true);
            eventSystem.SetSelectedGameObject (selectNo); 
        }
}

