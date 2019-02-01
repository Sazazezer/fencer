using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;
using UnityEngine.SceneManagement;

public class JournalList : MonoBehaviour {

/* 
 Look to list of journal entries, determine which has been found, and add them to the list.
 When button is clicked, displays the journal
*/
    public Button button;
    public GameObject panel;
    private string jsonData;
    private string filename;
    private int countDammit = 0;
    static readonly string JOURNAL_DATA = "JournalEntries.json";
	// Use this for initialization
	void Start () {
        filename = Path.Combine(Application.streamingAssetsPath, JOURNAL_DATA);
        if (SceneManager.GetActiveScene().buildIndex != 1){
            JournalCompile();
        }
	}

    public void JournalCompile(){
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }

        
        string jsonFromFile = File.ReadAllText(filename);
        JournalDataList list = JournalDataList.CreateFromJSON(jsonFromFile);
        countDammit = list.items.Count();
        if (File.Exists(filename)){

            for (int i = 0; i < countDammit; i++){
                if (list.items[i].lockedAway == 1){
                    button.GetComponentInChildren<Text>().text = list.items[i].content;
                    button.GetComponentInChildren<ButtonClick>().index = list.items[i].index;
                    button.GetComponentInChildren<ButtonClick>().content = list.items[i].content;
                    button.GetComponentInChildren<ButtonClick>().journal = list.items[i].journal;
                    Instantiate(button, panel.transform);
                }
            }
        }
    }

    public void AddNewJournal(int _newIndex){
        Debug.Log("Adding journal" + _newIndex);
        string jsonFromFile = File.ReadAllText(filename);
        JournalDataList list = JournalDataList.CreateFromJSON(jsonFromFile);
        int newIndex = _newIndex;
        Debug.Log(newIndex);
        list.items[newIndex].lockedAway = 1;
        jsonData = JsonUtility.ToJson(list, true);

            if (File.Exists(filename)){
                File.Delete(filename);
            }

            File.WriteAllText(filename, jsonData);
            JournalCompile();
    }

    public void ResetJournals(){
        filename = Path.Combine(Application.streamingAssetsPath, JOURNAL_DATA);
        string jsonFromFile = File.ReadAllText(filename);
        JournalDataList list = JournalDataList.CreateFromJSON(jsonFromFile);
        if (File.Exists(filename)){
            countDammit = list.items.Count();
            Debug.Log("Deleting Entires");
            for (int i = 0; i < countDammit; i++){
                list.items[i].lockedAway = 0;
                Debug.Log("Deleted" + i + "Entires");
                }
            }
        jsonData = JsonUtility.ToJson(list,true);
            if (File.Exists(filename)){
                File.Delete(filename);
            }

            File.WriteAllText(filename, jsonData);
    }        
    
}


