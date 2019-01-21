using UnityEngine;
using System.Collections;
using System.Collections.Generic;

    [System.Serializable]
    public class PuzzleLockDataList
    {
        public PuzzleLockData[] items;
 
        public static PuzzleLockDataList CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<PuzzleLockDataList>(jsonString);
        }
    }