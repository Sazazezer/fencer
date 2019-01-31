using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;
using UnityEngine.SceneManagement;

public class ItemList : MonoBehaviour {


    private string jsonData;
    private string filename;
    private int countDammit = 0;
    static readonly string Item_DATA = "ItemEntries.json";
    // Use this for initialization
    void Start () {
        filename = Path.Combine(Application.streamingAssetsPath, Item_DATA);
        if (SceneManager.GetActiveScene().buildIndex != 1){
            ItemCompile();
        }
    }

    public void ItemCompile(){
        
        string jsonFromFile = File.ReadAllText(filename);
        ItemDataList list = ItemDataList.CreateFromJSON(jsonFromFile);
        countDammit = list.items.Count();
        if (File.Exists(filename)){
            for (int i = 0; i < countDammit; i++){
                if(list.items[i].index == this.GetComponent<Pickup>().itemIndex){
                    if (list.items[i].itemPicked == 1){
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }

    public void SavePickup(int _newIndex){
        string jsonFromFile = File.ReadAllText(filename);
        ItemDataList list = ItemDataList.CreateFromJSON(jsonFromFile);
        int newIndex = _newIndex;
        list.items[newIndex].itemPicked = 1;
        jsonData = JsonUtility.ToJson(list);

            if (File.Exists(filename)){
                File.Delete(filename);
            }

            File.WriteAllText(filename, jsonData);
            ItemCompile();
    }

    public void ResetItems(){
        filename = Path.Combine(Application.streamingAssetsPath, Item_DATA);
        string jsonFromFile = File.ReadAllText(filename);
        ItemDataList list = ItemDataList.CreateFromJSON(jsonFromFile);
        if (File.Exists(filename)){
            countDammit = list.items.Count();
            Debug.Log("Deleting Entires");
            for (int i = 0; i < countDammit; i++){
                list.items[i].itemPicked = 0;
                Debug.Log("Deleted" + i + "Entires");
                }
            }
        jsonData = JsonUtility.ToJson(list);
            if (File.Exists(filename)){
                File.Delete(filename);
            }

            File.WriteAllText(filename, jsonData);
           // ItemCompile();
    }        
    
}


