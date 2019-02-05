using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [System.Serializable]
    public class DoorLockData
    {
        public int lockNumber;
        public string doorName;
        public int doorUnlocked;

 
        public static DoorLockData CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<DoorLockData>(jsonString);
        }
    }