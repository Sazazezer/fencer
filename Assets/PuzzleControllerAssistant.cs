using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleControllerAssistant : MonoBehaviour {

    public GameObject puzzleController;

    public void OnTrigger2DEnter(Collider2D puzzleController){
        Debug.Log("Weep");
        this.GetComponent<Button>().Select();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
