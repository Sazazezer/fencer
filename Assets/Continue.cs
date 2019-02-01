using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Continue : MonoBehaviour {

    static readonly string SAVE_FILE = "player.json";
    static readonly string ROOM_MOVE = "room.json";


    private string filename;
    private string roomFilename;
    private string jsonRoom;
    private string jsonData;
    private SaveData data;
    private NextRoom room;
    private bool roomTransition = false;
    //private GameObject currentDoor;
    GameObject[] doors; 

public void Load(){
        jsonData = JsonUtility.ToJson(data, true);

        filename = Path.Combine(Application.streamingAssetsPath, SAVE_FILE);

        string jsonFromFile = File.ReadAllText(filename);

        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);

        //Don't touch the stuff above. Variables go here.
        if (File.Exists(filename)){
            SceneManager.LoadScene(copy.sceneID);
        } else {

            //JUST DO NEW GAME AUTOMATICALLY
        //    saveScreen.GetComponent<SaveScreen>().Resume();
           // textBox.gameObject.SetActive(true);
           // textBox.text = "No Save File.";
        }

    }
}
