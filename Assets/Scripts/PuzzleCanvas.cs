using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzleCanvas : MonoBehaviour {

    public Canvas puzzle;
    public GameObject firstSelected;
    public GameObject player;

    public void Start(){
        player = GameObject.Find("Player");
    }

	
    public void Activate(){
        eventSystem.SetSelectedGameObject (firstSelected);
        Time.timeScale = 0.000001f;
        puzzle.GetComponent<Canvas> ().enabled = true;  

    }
protected EventSystem eventSystem{
        get { return GameObject.Find ("EventSystem").GetComponent<EventSystem> (); }
    }

    public void Deactivate(){

        if(!player.activeInHierarchy){
            player.SetActive(true);
        }

        GameObject.Find("Player").GetComponent<PlayerUIManager>().inPuzzle = false;
        puzzle.GetComponent<Canvas> ().enabled = false;
        Destroy(gameObject);
        Time.timeScale = 1f;
    }
}
