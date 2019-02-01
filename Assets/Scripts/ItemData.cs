using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [System.Serializable]
    public class ItemData
    {
        public int index;
        public string itemName;
        public int itemPicked;

 
        public static ItemData CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<ItemData>(jsonString);
        }
    }