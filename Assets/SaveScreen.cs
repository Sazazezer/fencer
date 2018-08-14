using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScreen : MonoBehaviour {

    public static bool SaveMenuUp = false;
    public GameObject saveMenuUI;
   // public GameObject savePoint;
    GameObject[] savePoints; 
    public GameObject player;
    public float savePointRange = 11;

    void Start(){
        savePoints = GameObject.FindGameObjectsWithTag("SavePoint");
        Resume();
    }

    void Update () {


        if(Input.GetButtonDown("Fire1")){//this is activating straight away after saving!
            foreach(GameObject savePoint in savePoints){
                float dist = Vector3.Distance(player.transform.position, savePoint.transform.position);
                if(dist < savePointRange){
                    if(SaveMenuUp){
                        Resume();
                    } else{
                        Paused();
                    }
                }
            }
        }
    }

    public void Resume(){
        saveMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SaveMenuUp = false;
    }

    void Paused(){
        saveMenuUI.SetActive(true);
        Time.timeScale = 0f;
        SaveMenuUp = true;

    }
}
