using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [System.Serializable]
    public class JournalData
    {
        public int index;
        public int lockedAway;
        public string content;
        public string journal;
 
        public static JournalData CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<JournalData>(jsonString);
        }
    }