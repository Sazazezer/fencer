using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.IO;

public class NewGame : MonoBehaviour {

    static readonly string SAVE_FILE = "player.json";
    static readonly string ROOM_MOVE = "room.json";

    public GameObject areYouSure;
    public GameObject oldButtons;
    public GameObject selectNo;
    private string filename;
    private string roomFilename;
    private string jsonData;
    private SaveData data;


    protected EventSystem eventSystem{
        get { return GameObject.Find ("EventSystem").GetComponent<EventSystem> (); }
    }

public void Load(){
        jsonData = JsonUtility.ToJson(data);

        filename = Path.Combine(Application.persistentDataPath, SAVE_FILE);

        //string jsonFromFile = File.ReadAllText(filename);

        //SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);

        //Don't touch the stuff above. Variables go here.
        if (File.Exists(filename)){
          //  oldButtons.gameObject.SetActive(false);
            areYouSure.gameObject.SetActive(true);
            eventSystem.SetSelectedGameObject (selectNo); 
        } else {
            SceneManager.LoadScene("OpeningScene");

            //JUST DO NEW GAME AUTOMATICALLY
        //    saveScreen.GetComponent<SaveScreen>().Resume();
           // textBox.gameObject.SetActive(true);
           // textBox.text = "No Save File.";
        }

    }
}
