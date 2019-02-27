using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzleCanvas : MonoBehaviour {

    public Canvas puzzle;
    public GameObject firstSelected;
	
    public void Activate(){
        Time.timeScale = 0f;
        puzzle.GetComponent<Canvas> ().enabled = true;  

    }

    public void Deactivate(){
        GameObject.Find("Player").GetComponent<PlayerUIManager>().inPuzzle = false;
        puzzle.GetComponent<Canvas> ().enabled = false;
        Destroy(gameObject);
        Time.timeScale = 1f;
    }
}
