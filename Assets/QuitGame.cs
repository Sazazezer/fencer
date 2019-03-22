using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour {

    public GameObject pauseMenuUI;
    public GameObject areYouSureUI;
    public GameObject canvas;

    void Start(){
        FirstTimeClose();
    }

    public void Yes(){
        SceneManager.LoadScene("GameWindows");
    }

    public void No(){
        areYouSureUI.SetActive(false);
        canvas.GetComponent<Pause>().Paused();
    }

    public void FirstTimeClose(){
        areYouSureUI.SetActive(false);    
    }
}
