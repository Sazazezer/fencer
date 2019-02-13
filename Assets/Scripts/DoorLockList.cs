using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;
using UnityEngine.SceneManagement;

public class DoorLockList : MonoBehaviour {


    private string jsonData;
    private string filename;
    private int countDammit = 0;
    static readonly string DoorLock_DATA = "DoorLockEntries.json";
    // Use this for initialization
    void Start () {
        filename = Path.Combine(Application.streamingAssetsPath, DoorLock_DATA);
        if (SceneManager.GetActiveScene().buildIndex != 1){
            DoorLockCompile();
        }
    }

    public void DoorLockCompile(){
        
        string jsonFromFile = File.ReadAllText(filename);
        DoorLockDataList list = DoorLockDataList.CreateFromJSON(jsonFromFile);
        countDammit = list.items.Count();
        if (File.Exists(filename)){
            for (int i = 0; i < countDammit; i++){
                if(list.items[i].lockNumber == this.GetComponent<DoorLock>().lockNumber){
                    if (list.items[i].doorUnlocked == 1){
                        this.GetComponent<DoorLock>().locked = false;
                    }
                }
            }
        }
    }

    public void UnlockDoorSave(int _newIndex){
        string jsonFromFile = File.ReadAllText(filename);
        DoorLockDataList list = DoorLockDataList.CreateFromJSON(jsonFromFile);
        int newIndex = _newIndex;
        list.items[newIndex].doorUnlocked = 1;
        list.items[newIndex].doorName = this.GetComponent<DoorLock>().doorName;;
        jsonData = JsonUtility.ToJson(list, true);

            if (File.Exists(filename)){
        //        File.Delete(filename);
            }

            File.WriteAllText(filename, jsonData);
        //    DoorLockCompile();
    }

    public void ResetDoorLocks(){
        filename = Path.Combine(Application.streamingAssetsPath, DoorLock_DATA);
        string jsonFromFile = File.ReadAllText(filename);
        DoorLockDataList list = DoorLockDataList.CreateFromJSON(jsonFromFile);
        if (File.Exists(filename)){
            countDammit = list.items.Count();
            Debug.Log("Deleting Doors");
            for (int i = 0; i < countDammit; i++){
                list.items[i].doorUnlocked = 0;
             //   Debug.Log("Deleted" + i + "Doors");
                }
            }
        jsonData = JsonUtility.ToJson(list, true);
            if (File.Exists(filename)){
         //       File.Delete(filename);
            }

            File.WriteAllText(filename, jsonData);
          //  DoorLockCompile();
    }        
    
}


