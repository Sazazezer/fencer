using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LocationList : MonoBehaviour {

    static readonly string SAVE_FILE = "player.json";
    static readonly string ROOM_MOVE = "room.json";

    public GameObject player;
    public GameObject saveScreen;
    public Text textBox;
    private string filename;
    private string roomFilename;
    private string jsonRoom;
    private string jsonData;
    private SaveData data;
    private NextRoom room;
    private bool roomTransition = false;
    GameObject[] doors; 


	// Use this for initialization

    public void Start(){
            //check for room transition and move player accordingly
            jsonRoom = JsonUtility.ToJson(room);
            roomFilename = Path.Combine(Application.streamingAssetsPath, ROOM_MOVE);

        if (SceneManager.GetActiveScene().buildIndex != 1){
            LoadUpRoom();     
        }
    }

    public void Save(){

        data = new SaveData() { 
            //Saved Variables go here. Don't forget to add them to SaveData.cs too
            playerPosition = player.transform.position,
            sceneID = SceneManager.GetActiveScene().buildIndex,
           // dialogue = GameObject.FindObjectOfType<DialogueStorage>().variables
        };
        jsonData = JsonUtility.ToJson(data, true);
        filename = Path.Combine(Application.streamingAssetsPath, SAVE_FILE);
            if (File.Exists(filename)){
                File.Delete(filename);
            }
            File.WriteAllText(filename, jsonData);
        saveScreen.GetComponent<SaveScreen>().Resume();
        textBox.gameObject.SetActive(true);
        textBox.text = "Game Saved.";
    }

    public void Load(){
        jsonData = JsonUtility.ToJson(data, true);
        filename = Path.Combine(Application.streamingAssetsPath, SAVE_FILE);
        string jsonFromFile = File.ReadAllText(filename);
        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
        //Don't touch the stuff above. Variables go here.
        if (File.Exists(filename)){
            SceneManager.LoadScene(copy.sceneID);
        } else {
            saveScreen.GetComponent<SaveScreen>().Resume();
            textBox.gameObject.SetActive(true);
            textBox.text = "No Save File.";
        }

    }

    public void ResetGameData(){

        data = new SaveData() { 
            //Saved Variables go here. Don't forget to add them to SaveData.cs too
            playerPosition = new Vector3(-164.37689208984376f,-807.9430541992188f,0.0f),
            sceneID = 3,
            //dialogue = GameObject.FindObjectOfType<DialogueStorage>().variables
        };
        jsonData = JsonUtility.ToJson(data, true);
        filename = Path.Combine(Application.streamingAssetsPath, SAVE_FILE);
            if (File.Exists(filename)){
                File.Delete(filename);
            }

            File.WriteAllText(filename, jsonData);
    }

    public void Cancel(){
        saveScreen.GetComponent<SaveScreen>().Resume();
    }

    public void RoomMove(){
        roomTransition = true;
    }

    public void LoadUpRoom(){
                    //Don't touch the stuff above. Variables go here.
        if (File.Exists(roomFilename)){
            string jsonFromRoom = File.ReadAllText(roomFilename);
            NextRoom roomData = JsonUtility.FromJson<NextRoom>(jsonFromRoom); 
            doors = GameObject.FindGameObjectsWithTag("Door");
            if (roomData.roomTransition==true){
                //get the door player is suppose to come through
                foreach (GameObject newDoor in doors){

                    int doorID = newDoor.GetComponent<DoorTransition>().door;
                    if (doorID == roomData.iLeadTo){
                        Debug.Log(newDoor.GetComponent<DoorTransition>().doorSide);
                            player.transform.position = new Vector3(newDoor.transform.position.x, newDoor.transform.position.y, 0);
                    }
                }
                File.Delete(roomFilename);
            }
        }else{
            jsonData = JsonUtility.ToJson(data, true);
            filename = Path.Combine(Application.streamingAssetsPath, SAVE_FILE);
            string jsonFromFile = File.ReadAllText(filename);
            SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile); 
            //Don't touch the stuff above. Variables go here.
             player.transform.position = copy.playerPosition;
             //GameObject.FindObjectOfType<DialogueStorage>().variables = copy.dialogue;
            //Don't touch the stuff below
            saveScreen.GetComponent<SaveScreen>().Resume();
            textBox.gameObject.SetActive(true);
            textBox.text = "Game Loaded.";
        }  
    }
    
}
