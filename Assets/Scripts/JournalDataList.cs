using UnityEngine;
using System.Collections;
using System.Collections.Generic;

    [System.Serializable]
    public class JournalDataList
    {
        public JournalData[] items;
 
        public static JournalDataList CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<JournalDataList>(jsonString);
        }
    }