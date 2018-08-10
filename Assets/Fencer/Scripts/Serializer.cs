using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Serializer : MonoBehaviour {

    static readonly string SAVE_FILE = "player.json";

    public GameObject player;
    public GameObject saveScreen;
    public Text textBox;
    private string filename;
    private string json;
    private SaveData data;


	// Use this for initialization

    public void Save(){

        data = new SaveData() { 
            //Saved Variables go here. Don't forget to add them to SaveData.cs too
            name = "Zam", 
            kills = 0,
            playerPosition = player.transform.position
        };

        json = JsonUtility.ToJson(data);

        filename = Path.Combine(Application.persistentDataPath, SAVE_FILE);

            if (File.Exists(filename)){
                File.Delete(filename);
            }

            File.WriteAllText(filename, json);

        Debug.Log("Player saved to " + filename); 
        Debug.Log(data.playerPosition);
        saveScreen.GetComponent<SaveScreen>().Resume();
        textBox.gameObject.SetActive(true);
        textBox.text = "Game Saved.";


    }

    public void Load(){
        json = JsonUtility.ToJson(data);

        filename = Path.Combine(Application.persistentDataPath, SAVE_FILE);

        string jsonFromFile = File.ReadAllText(filename);

        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);

        //Don't touch the stuff above. Variables go here.

        player.transform.position = copy.playerPosition;

        Debug.Log("Save Loaded");
        saveScreen.GetComponent<SaveScreen>().Resume();
        textBox.gameObject.SetActive(true);
        textBox.text = "Game Loaded.";

    }

    void Update(){

         if (Input.GetKeyDown(KeyCode.F5)){
            Save();
         }
         if (Input.GetKeyDown(KeyCode.F6)){
            Load();
         }



    }
}
