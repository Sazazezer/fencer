using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [System.Serializable]
    public class PuzzleLockData
    {
        public int index;
        public int puzzleSolved;

 
        public static PuzzleLockData CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<PuzzleLockData>(jsonString);
        }
    }