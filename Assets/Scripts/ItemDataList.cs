using UnityEngine;
using System.Collections;
using System.Collections.Generic;

    [System.Serializable]
    public class ItemDataList
    {
        public ItemData[] items;
 
        public static ItemDataList CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<ItemDataList>(jsonString);
        }
    }