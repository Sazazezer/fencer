using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {

    public GameObject gameOverPanel;
    public Text gameOverText;
    public static bool playerDead;
    public int deathCount = 30;

    void Awake ()
    {
    playerDead = false;
    gameOverPanel.SetActive(false);

    }
    void Update ()
    {

		if (playerDead == true){
			if (deathCount != 0){
				deathCount--;
			} else {
        	gameOverPanel.SetActive(true);
        	gameOverText.text = " Oh No. \n Death! \n Press R to Restart";
        	}
        }
        if (Input.GetKeyDown("r")){
            	SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
         	}
    	}
    }
