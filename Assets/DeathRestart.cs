using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathRestart : MonoBehaviour
{
	public GameObject player;
	public string currentScene;
	public AudioClip killSound; 
	public GameObject fadeCanvas;
    public GameObject fadePanelKill;
    private Fade fade;

    void Awake(){
        fadeCanvas = GameObject.Find("FadeCanvas");
        fadePanelKill = GameObject.Find("FadePanel");
    }

	void Start(){
		Scene scene = SceneManager.GetActiveScene();
		currentScene = scene.name;
         GetComponent<AudioSource> ().playOnAwake = false;
         GetComponent<AudioSource> ().clip = killSound;
	}
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col)
    {
    	if (col.gameObject.tag == "Player"){
    		fadeCanvas.GetComponent<Fade>().CutToBlack();
    		GetComponent<AudioSource> ().Play ();
        	StartCoroutine(playKillEffect());
    	}
    }

    public IEnumerator playKillEffect(){
    	yield return new WaitForSeconds(1);
    	Application.LoadLevel(currentScene); 
    }
}
