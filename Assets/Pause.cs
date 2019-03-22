using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public static bool GamePaused = false;
	public GameObject pauseMenuUI;
    public GameObject areYouSureUI;
    public GameObject resumeButton;
    public GameObject areYouSureUINoButton;

    void Start(){
        Resume();
    }
    protected EventSystem eventSystem{
        get { return GameObject.Find ("EventSystem").GetComponent<EventSystem> (); }
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

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Paused(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        eventSystem.SetSelectedGameObject (resumeButton);
    }

    public void QuitGame(){
        areYouSureUI.SetActive(true);
        eventSystem.SetSelectedGameObject (areYouSureUINoButton);
    }
}
