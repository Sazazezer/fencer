using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;

public class UniqueVariablesList : MonoBehaviour {

    private string jsonData;
    private string filename;
    private int countDammit = 0;
    static readonly string UNIQUE_VARIABLES_DATA = "UniqueVariablesEntries.json";
	// Use this for initialization
	void Start () {
        filename = Path.Combine(Application.streamingAssetsPath, UNIQUE_VARIABLES_DATA);
      //  JournalCompile();
	}

    public int GetUniqueVariable(string _parameters){
        string jsonFromFile = File.ReadAllText(filename);
        UniqueVariablesDataList list = UniqueVariablesDataList.CreateFromJSON(jsonFromFile);
        countDammit = list.items.Count();
            for (int i = 0; i < countDammit; i++){
                if (list.items[i].variableName == _parameters){
                    int returnVariableValue = list.items[i].currentValue;
                    Debug.Log(returnVariableValue);
                    return returnVariableValue;
                } else {
                    Debug.Log("you're missing a value somewhere, or you've used an incorrect variable name!");
                    return 0;
                }
                    Debug.Log("you're missing a value somewhere, or you've used an incorrect variable name!");
                    return 0;
            }
            Debug.Log("you're missing a value somewhere, or you've used an incorrect variable name!");
            return 0;
        }

    public void SetUniqueVariable(string _parameters, int _newValue){
        string jsonFromFile = File.ReadAllText(filename);
        UniqueVariablesDataList list = UniqueVariablesDataList.CreateFromJSON(jsonFromFile);
        countDammit = list.items.Count();
        if (File.Exists(filename)){

            for (int i = 0; i < countDammit; i++){
                if (list.items[i].variableName == _parameters){
                    list.items[i].currentValue = _newValue;
                    jsonData = JsonUtility.ToJson(list);
                    if (File.Exists(filename)){
                        File.Delete(filename);
                    }

                    File.WriteAllText(filename, jsonData);
                }
            }
        }
    }

    public void ResetUniqueVariables(){
        string jsonFromFile = File.ReadAllText(filename);
        UniqueVariablesDataList list = UniqueVariablesDataList.CreateFromJSON(jsonFromFile);
        if (File.Exists(filename)){
            countDammit = list.items.Count();
            Debug.Log("Cleaning Variable");
            for (int i = 0; i < countDammit; i++){
                list.items[i].currentValue = 0;
                }
            }
        jsonData = JsonUtility.ToJson(list);
            if (File.Exists(filename)){
                File.Delete(filename);
            }

            File.WriteAllText(filename, jsonData);
    }        
    
}


