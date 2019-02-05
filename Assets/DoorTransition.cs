using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public enum DoorSide {
    leftdown = -50,
    rightup = 50,
}
public enum DoorDir{
    horizontal,
    vertical
}

public class DoorTransition : MonoBehaviour {
 
    public string goToScene;
  //  public float nextDoorX;
  //  public float nextDoorY;
    public int door;
    public int leadsTo;
    private NextRoom room;
    private string json;
    private string filename;
    public DoorSide doorSide;
    public DoorDir doorDir;
    static readonly string ROOM_MOVE = "room.json";
 
     void OnTriggerStay2D(Collider2D other){
       if (Input.GetButtonUp("Up") && other.tag == "Player" ){
            if (this.GetComponent<DoorLock>().locked == false){
                GameObject.FindObjectOfType<DialogueList>().Save();
                Debug.Log("Boop");
                    //   target.transform.position = new Vector3(xPosition, yPosition, 0);
                    room = new NextRoom() { 
                    //Saved Variables go here. Don't forget to add them to SaveData.cs too
                    iLeadTo = leadsTo,
                    roomTransition = true
                    };
                    json = JsonUtility.ToJson(room);
                    filename = Path.Combine(Application.streamingAssetsPath, ROOM_MOVE);
                    if (File.Exists(filename)){
                        File.Delete(filename);
                    }
                    File.WriteAllText(filename, json);
                    Debug.Log("Is it me?");
                    Application.LoadLevel(goToScene);
            } else {
                GameObject.Find("GameControls").GetComponent<TextBoxManager>().UpdateTextBox("The door is locked. Sucks to be you.");
            }
            }
        }
}