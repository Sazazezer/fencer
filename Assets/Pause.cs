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
    public GameObject controlsUI;
    public GameObject areYouSureUINoButton;
    public GameObject controlsBackButton;

    void Start(){
        Resume();
    }
    protected EventSystem eventSystem{
        get { return GameObject.Find ("EventSystem").GetComponent<EventSystem> (); }
    }

	void Update () {
        Debug.Log(GamePaused);
        if(GamePaused){
            Time.timeScale = 0f;
        }

		if(Input.GetButtonDown("Cancel") || Input.GetMouseButtonDown(0)){
            if(GamePaused && pauseMenuUI.activeSelf == true){
                Resume();
            } else if (GamePaused && pauseMenuUI.activeSelf == false){
                areYouSureUI.SetActive(false);
                controlsUI.SetActive(false);
                Paused();
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
        Debug.Log("Beep");
        eventSystem.SetSelectedGameObject (resumeButton);
        Debug.Log("Boop");
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void Controls(){
        controlsUI.SetActive(true);
        eventSystem.SetSelectedGameObject (controlsBackButton); 
        pauseMenuUI.SetActive(false);      
    }

    public void QuitGame(){
        areYouSureUI.SetActive(true);
        eventSystem.SetSelectedGameObject (areYouSureUINoButton);
        pauseMenuUI.SetActive(false);
    }
}
