using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DoorTransition : MonoBehaviour {
 
    public string goToScene;
  //  public float nextDoorX;
  //  public float nextDoorY;
    public int door;
    public int leadsTo;
    private NextRoom room;
    private string json;
    private string filename;
    static readonly string ROOM_MOVE = "room.json";
 
     void OnCollisionEnter2D(Collision2D target){
        Debug.Log("Boop");
         if(target.gameObject.tag == "Player"){
            //   target.transform.position = new Vector3(xPosition, yPosition, 0);
            room = new NextRoom() { 
            //Saved Variables go here. Don't forget to add them to SaveData.cs too
            iLeadTo = leadsTo,
            roomTransition = true
            };
            json = JsonUtility.ToJson(room);
            filename = Path.Combine(Application.persistentDataPath, ROOM_MOVE);
            if (File.Exists(filename)){
                File.Delete(filename);
            }
            File.WriteAllText(filename, json);
            Debug.Log("Is it me?");
            Application.LoadLevel(goToScene);
        }    
    }
}
