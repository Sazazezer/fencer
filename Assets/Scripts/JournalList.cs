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
    public Canvas journal;
    public Button button;
    public GameObject panel;
    public GameObject highlightIcon;
    public GameObject textPanel;
    public int highlightSlot;
    private string jsonData;
    private string filename;
    public List<Button> buttons = new List<Button>();
    private int countDammit = 0;
    static readonly string JOURNAL_DATA = "JournalEntries.json";
    // Use this for initialization
    void Start () {
        filename = Path.Combine(Application.streamingAssetsPath, JOURNAL_DATA);
        if (SceneManager.GetActiveScene().buildIndex != 1){
            JournalCompile();
        }
        highlightSlot = 0;

    }

    void Update(){

        for(var k = 0 ; k < buttons.Count(); k++){
            Debug.Log("Button " + k + "is " + buttons[k]);
        }

        if(journal.GetComponent<JournalCanvas>().panelSelected == 0){
            if (buttons[highlightSlot]!= null){ //buttons.Count() > 0
            highlightIcon.transform.position =  buttons[highlightSlot].transform.position;
            textPanel.GetComponent<Image>().enabled = false;                
            }

          } else if(journal.GetComponent<JournalCanvas>().panelSelected == 1){
             //   highlightIcon.transform.position =  textPanel.transform.position;
                textPanel.GetComponent<Image>().enabled = true;
         }


        if (journal.GetComponent<Canvas> ().enabled == true){
            buttons[highlightSlot].GetComponent<ButtonClick>().SendToJournalTextPanel();

            if(journal.GetComponent<JournalCanvas>().panelSelected == 0){

                if (Input.GetButtonDown("Right")){
                    journal.GetComponent<JournalCanvas>().panelSelected = 1;
                   // Debug.Log("Text selected");

                }
            }
            if(journal.GetComponent<JournalCanvas>().panelSelected == 1){

                if (Input.GetButtonDown("Left")){
                    journal.GetComponent<JournalCanvas>().panelSelected = 0;
                  //  Debug.Log("List selected");
                }
            }
            if(highlightSlot != 0 && journal.GetComponent<JournalCanvas>().panelSelected == 0){
                if (Input.GetButtonDown("Up")){
                    GameObject.Find("JournalTextScrollbar").GetComponent<ScrollMovement>().ResetScrollbar();
                    highlightSlot--;
                }
            }
            if(highlightSlot != buttons.Count()-1 && journal.GetComponent<JournalCanvas>().panelSelected == 0){
                if (Input.GetButtonDown("Down")){
                    GameObject.Find("JournalTextScrollbar").GetComponent<ScrollMovement>().ResetScrollbar();
                    highlightSlot++;
                    Debug.Log("Hi");

                }
            }

        }
    }


    public void JournalCompile(){
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);

        }
        buttons.Clear();
        filename = Path.Combine(Application.streamingAssetsPath, JOURNAL_DATA);
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
                    var newButton = Instantiate(button, panel.transform);
                    buttons.Add(newButton);
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
             //   Debug.Log("Deleted" + i + "Entires");
                }
            }
        jsonData = JsonUtility.ToJson(list,true);
            if (File.Exists(filename)){
                File.Delete(filename);
            }

            File.WriteAllText(filename, jsonData);
    }        
    
}