using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;

public class InventoryList : MonoBehaviour {

/* 
 Look to list of journal entries, determine which has been found, and add them to the list.
 When button is clicked, displays the journal
*/
    private Inventory inventory;
    private string jsonData;
    private string filename;

    public string itemName;
    public string itemDescription;
    public string KeyID;
    public string itemIndestructible;

    static readonly string INVENTORY_DATA = "InventoryEntries.json";
	// Use this for initialization
	void Start () {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        filename = Path.Combine(Application.streamingAssetsPath, INVENTORY_DATA);
       // JournalCompile();
	}

    public void SaveInventory(){
        string jsonFromFile = File.ReadAllText(filename);
        Debug.Log(jsonFromFile);
        InventoryDataList list = InventoryDataList.CreateFromJSON(jsonFromFile);
        Debug.Log(list);
        for (int i = 0; i < inventory.slots.Count(); i++){
            list.items[i].itemName = inventory.slots[i].itemName;
            list.items[i].itemDescription = inventory.slots[i].itemDescription;
            list.items[i].KeyID = inventory.slots[i].KeyID;
            list.items[i].itemIndestructible = inventory.slots[i].itemIndestructible;
            list.items[i].prefabName = inventory.slots[i].prefabName;

        }

        jsonData = JsonUtility.ToJson(list, true);
        Debug.Log(jsonData);

            if (File.Exists(filename)){
                File.Delete(filename);
            }

            File.WriteAllText(filename, jsonData);
    }

    public void LoadInventory(){
            string jsonFromFile = File.ReadAllText(filename);
            InventoryDataList list = InventoryDataList.CreateFromJSON(jsonFromFile);
        if (File.Exists(filename)){
            for (int j = 0; j < inventory.slots.Count(); j++){
             if (list.items[j].KeyID != 0){
                Debug.Log("Assigning items to slot " + j);
                inventory.items[j] = 1; // makes sure that the slot is now considered FULL
             //   instance = Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with it
                inventory.slots[j].itemName = list.items[j].itemName;
                inventory.slots[j].itemDescription = list.items[j].itemDescription;
                GameObject instance = Instantiate(Resources.Load(list.items[j].prefabName, typeof(GameObject)), inventory.slots[j].transform, false) as GameObject;
                inventory.slots[j].itemObject = instance;
                inventory.slots[j].KeyID = list.items[j].KeyID;
                inventory.slots[j].itemIndestructible = list.items[j].itemIndestructible;
                inventory.slots[j].prefabName = list.items[j].prefabName;
                instance.GetComponent<Item>().slotNumber = j;
                }               
            }
        }    
    }

    public void ResetInventory(){
        string jsonFromFile = File.ReadAllText(filename);
        InventoryDataList list = InventoryDataList.CreateFromJSON(jsonFromFile);
        for (int i = 0; i < inventory.slots.Count(); i++){
            list.items[i].itemName ="";
            list.items[i].itemDescription = "";
            list.items[i].KeyID = 0;
            list.items[i].itemIndestructible = false;
            list.items[i].prefabName = "";
            inventory.items[i] = 0; // makes sure that the slot is now considered EMPTY
            inventory.slots[i].itemName = "";
            inventory.slots[i].itemDescription = "";
            Destroy(inventory.slots[i].itemObject);
            inventory.slots[i].itemObject = null;
            inventory.slots[i].KeyID = 0;
            inventory.slots[i].itemIndestructible = false;
        }

        jsonData = JsonUtility.ToJson(list, true);
        Debug.Log(jsonData);

            if (File.Exists(filename)){
                File.Delete(filename);
            }

            File.WriteAllText(filename, jsonData);
    }

}