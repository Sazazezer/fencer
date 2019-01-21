using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [System.Serializable]
    public class InventoryData
    {
        public string itemName;
        public string itemDescription;
        public int KeyID;
        public bool itemIndestructible;
        public string prefabName;
 
        public static InventoryData CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<InventoryData>(jsonString);
        }
    }