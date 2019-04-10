using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsUI : MonoBehaviour {

    public GameObject pauseMenuUI;
    public GameObject controlsUI;
    public GameObject canvas;

    void Start(){
        FirstTimeClose();
    }

    public void Back(){
        controlsUI.SetActive(false);
        canvas.GetComponent<Pause>().Paused();
    }

    public void FirstTimeClose(){
        controlsUI.SetActive(false);    
    }
}
