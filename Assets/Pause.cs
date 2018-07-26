using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public static bool GamePaused = false;
	public GameObject pauseMenuUI;

    void Start(){
        Resume();
    }

	void Update () {


		if(Input.GetButtonDown("Cancel")){
            if(GamePaused){
                Resume();
            } else{
                Paused();
            }
        }
	}

    void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Paused(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;

    }
}
