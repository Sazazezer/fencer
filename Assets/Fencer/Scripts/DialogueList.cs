using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;
using Newtonsoft.Json.Linq;
using System.IO;
//NONE OF THIS SHIT IS NEEDED. IT CAN GO! YAY! BE HAPPY FUTURE SELF! PAST YOU FOUND A BETTER WAY!
//HELLO FUTURE FUTURE SELF. PAST FUTURE SELF HERE. YOU DO NEED ALL OF THIS. DON'T GET RID OF IT. STILL BE HAPPY THOUGH.
public class DialogueList : MonoBehaviour {
    public DialogueStorage variableStorage;
    public DialogueRunner dialogueRunner;
    public string externalJson = "";
    static readonly string DIALOGUE_FILE = "dialogue.json";
    private string filename;

    void Start(){
        variableStorage = GameObject.FindObjectOfType<DialogueStorage>();
        filename = Path.Combine(Application.streamingAssetsPath, DIALOGUE_FILE);
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.K)) {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            LoadFromJson();
        }
    }
    
    public void Save () {
      //  variableStorage = GameObject.FindObjectOfType<DialogueStorage>();
        filename = Path.Combine(Application.streamingAssetsPath, DIALOGUE_FILE);
        YarnSaveState yss = new YarnSaveState(variableStorage.Variables, dialogueRunner.dialogue.visitedNodeCount);
        //Save to JSON here

        File.WriteAllText(filename, Newtonsoft.Json.JsonConvert.SerializeObject(yss));
       // string json = Newtonsoft.Json.JsonConvert.SerializeObject(yss);
      //  Debug.Log(yss.values);
    }
        
    public void LoadFromJson () {   
       // variableStorage = GameObject.FindObjectOfType<DialogueStorage>();
        filename = Path.Combine(Application.streamingAssetsPath, DIALOGUE_FILE);
        string jsonFromFile = File.ReadAllText(filename);
        YarnSaveState yss = Newtonsoft.Json.JsonConvert.DeserializeObject<YarnSaveState>(jsonFromFile);
        foreach(var v in yss.values) {
            variableStorage.SetValue(v.Key, v.Value);

        }
        dialogueRunner.dialogue.visitedNodeCount = yss.visitedNodes;
    }

    public void ResetDialogue(){

     /*   data = new SaveData() { 
            //Saved Variables go here. Don't forget to add them to SaveData.cs too
            playerPosition = new Vector3(-164.37689208984376f,-807.9430541992188f,0.0f),
            sceneID = 3,
            //dialogue = GameObject.FindObjectOfType<DialogueStorage>().variables
        };
        jsonData = JsonUtility.ToJson(data, true);*/
        filename = Path.Combine(Application.streamingAssetsPath, DIALOGUE_FILE);
            if (File.Exists(filename)){
                File.Delete(filename);
            }

       //     File.WriteAllText(filename, jsonData);
    }
        

    class YarnSaveState {
        public Dictionary<string, Yarn.Value> values;
        public Dictionary<string, int> visitedNodes;
        public YarnSaveState (Dictionary<string, Yarn.Value> _values, Dictionary<string, int> _visitedNodes) {
            values = _values;
            visitedNodes = _visitedNodes;
        }
    }

}