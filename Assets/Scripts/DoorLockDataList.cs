using UnityEngine;
using System.Collections;
using System.Collections.Generic;

    [System.Serializable]
    public class DoorLockDataList
    {
        public DoorLockData[] items;
 
        public static DoorLockDataList CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<DoorLockDataList>(jsonString);
        }
    }