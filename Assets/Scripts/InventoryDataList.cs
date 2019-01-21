using UnityEngine;
using System.Collections;
using System.Collections.Generic;

    [System.Serializable]
    public class InventoryDataList
    {
        public InventoryData[] items;
 
        public static InventoryDataList CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<InventoryDataList>(jsonString);
        }
    }