using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;
using UnityEngine.SceneManagement;

public class PuzzleLockList : MonoBehaviour {


    private string jsonData;
    private string filename;
    private int countDammit = 0;
    static readonly string PuzzleLock_DATA = "PuzzleLockEntries.json";
    // Use this for initialization
    void Start () {
        filename = Path.Combine(Application.streamingAssetsPath, PuzzleLock_DATA);
        if (SceneManager.GetActiveScene().buildIndex != 1){
            PuzzleLockCompile();
        }
    }

    public void PuzzleLockCompile(){
        
        string jsonFromFile = File.ReadAllText(filename);
        PuzzleLockDataList list = PuzzleLockDataList.CreateFromJSON(jsonFromFile);
        countDammit = list.items.Count();
        if (File.Exists(filename)){
            for (int i = 0; i < countDammit; i++){
                if(list.items[i].index == this.GetComponent<PuzzleLock>().puzzleLockIndex){
                    if (list.items[i].puzzleSolved == 1){
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }

    public void UnlockPuzzleSave(int _newIndex){
        string jsonFromFile = File.ReadAllText(filename);
        PuzzleLockDataList list = PuzzleLockDataList.CreateFromJSON(jsonFromFile);
        int newIndex = _newIndex;
        list.items[newIndex].puzzleSolved = 1;
        jsonData = JsonUtility.ToJson(list, true);

            if (File.Exists(filename)){
                File.Delete(filename);
            }

            File.WriteAllText(filename, jsonData);
            PuzzleLockCompile();
    }

    public void ResetPuzzleLocks(){
        filename = Path.Combine(Application.streamingAssetsPath, PuzzleLock_DATA);
        string jsonFromFile = File.ReadAllText(filename);
        PuzzleLockDataList list = PuzzleLockDataList.CreateFromJSON(jsonFromFile);
        if (File.Exists(filename)){
            countDammit = list.items.Count();
            Debug.Log("Deleting Entires");
            for (int i = 0; i < countDammit; i++){
                list.items[i].puzzleSolved = 0;
                Debug.Log("Deleted" + i + "Entires");
                }
            }
        jsonData = JsonUtility.ToJson(list, true);
            if (File.Exists(filename)){
                File.Delete(filename);
            }

            File.WriteAllText(filename, jsonData);
          //  PuzzleLockCompile();
    }        
    
}


