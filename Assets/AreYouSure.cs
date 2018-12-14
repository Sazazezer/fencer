﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.IO;

public class AreYouSure : MonoBehaviour {

    public GameObject areYouSure;
    public GameObject oldButtons;
    public GameObject newGame;

    static readonly string SAVE_FILE = "player.json";
    private string filename;

    protected EventSystem eventSystem{
        get { return GameObject.Find ("EventSystem").GetComponent<EventSystem> (); }
    }

    public void No(){
        areYouSure.gameObject.SetActive(false);
        oldButtons.gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject (newGame); 
    }

    public void Yes(){
       // jsonData = JsonUtility.ToJson(data);

        filename = Path.Combine(Application.persistentDataPath, SAVE_FILE);
        File.Delete(filename);
        SceneManager.LoadScene("OpeningScene");
    }

}
