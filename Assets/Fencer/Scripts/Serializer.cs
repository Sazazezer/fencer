using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Serializer : MonoBehaviour {

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
    //private GameObject currentDoor;
    GameObject[] doors; 


	// Use this for initialization

    public void Start(){
            //check for room transition and move player accordingly
            jsonRoom = JsonUtility.ToJson(room);
            roomFilename = Path.Combine(Application.persistentDataPath, ROOM_MOVE);

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
                            Debug.Log("Within the Start room stuff");
                            int doorSideInt = (int)newDoor.GetComponent<DoorTransition>().doorSide;
                            Debug.Log(newDoor.GetComponent<DoorTransition>().doorSide);
                            if (newDoor.GetComponent<DoorTransition>().doorDir == DoorDir.horizontal){
                                player.transform.position = new Vector3(newDoor.transform.position.x+doorSideInt, newDoor.transform.position.y, 0);
                            } else {
                                player.transform.position = new Vector3(newDoor.transform.position.x, newDoor.transform.position.y + doorSideInt, 0);
                            }
                        }
                    }
                    File.Delete(roomFilename);
                }
            }else{
                jsonData = JsonUtility.ToJson(data);

                filename = Path.Combine(Application.persistentDataPath, SAVE_FILE);

                string jsonFromFile = File.ReadAllText(filename);

                SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile); 
                //Don't touch the stuff above. Variables go here.
                 player.transform.position = copy.playerPosition;
                 Debug.Log("Deep within Start");
                //Don't touch the stuff below

                saveScreen.GetComponent<SaveScreen>().Resume();
                textBox.gameObject.SetActive(true);
                textBox.text = "Game Loaded.";
            }
            
        }

    public void Save(){

        data = new SaveData() { 
            //Saved Variables go here. Don't forget to add them to SaveData.cs too
            name = "Zam", 
            kills = 0,
            playerPosition = player.transform.position,
            sceneID = SceneManager.GetActiveScene().buildIndex
        };

        jsonData = JsonUtility.ToJson(data);

        filename = Path.Combine(Application.persistentDataPath, SAVE_FILE);

            if (File.Exists(filename)){
                File.Delete(filename);
            }

            File.WriteAllText(filename, jsonData);

        Debug.Log(data.playerPosition);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        saveScreen.GetComponent<SaveScreen>().Resume();
        textBox.gameObject.SetActive(true);
        textBox.text = "Game Saved.";
        Debug.Log("Hello from Save");


    }

    public void Load(){
        jsonData = JsonUtility.ToJson(data);

        filename = Path.Combine(Application.persistentDataPath, SAVE_FILE);

        string jsonFromFile = File.ReadAllText(filename);

        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);

        //Don't touch the stuff above. Variables go here.
        if (File.Exists(filename)){
            Debug.Log("I do stuff");
            SceneManager.LoadScene(copy.sceneID);
        } else {


            saveScreen.GetComponent<SaveScreen>().Resume();
            textBox.gameObject.SetActive(true);
            textBox.text = "No Save File.";
        }

    }

    public void Cancel(){
        saveScreen.GetComponent<SaveScreen>().Resume();
    }

    public void RoomMove(){
        roomTransition = true;
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
