using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartButton : MonoBehaviour {
     
         void Update() {



         	if (Input.GetKeyDown("r")){
             SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
         	}
         }
     
     }
