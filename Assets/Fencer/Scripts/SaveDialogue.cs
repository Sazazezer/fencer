using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;
using Newtonsoft.Json.Linq;
using System.IO;

public class SaveDialogue : MonoBehaviour {
    public DialogueStorage variableStorage;
    public DialogueRunner dialogueRunner;
    public string externalJson = "";
    static readonly string SAVE_FILE = "dialogue.json";
    private string filename;

    void Start(){
        variableStorage = GameObject.FindObjectOfType<DialogueStorage>();
        filename = Path.Combine(Application.persistentDataPath, SAVE_FILE);
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.K)) {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            LoadFromJson();
        }
    }
    
    void Save () {
        YarnSaveState yss = new YarnSaveState(variableStorage.Variables, dialogueRunner.dialogue.visitedNodeCount);
        //Save to JSON here

        File.WriteAllText(filename, Newtonsoft.Json.JsonConvert.SerializeObject(yss));
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(yss);
        Debug.Log(json);
    }
        
    void LoadFromJson () {   

        string jsonFromFile = File.ReadAllText(filename);

        YarnSaveState yss = Newtonsoft.Json.JsonConvert.DeserializeObject<YarnSaveState>(jsonFromFile);
        foreach(var v in yss.values) {
            variableStorage.SetValue(v.Key, v.Value);
        }

        dialogueRunner.dialogue.visitedNodeCount = yss.visitedNodes;
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