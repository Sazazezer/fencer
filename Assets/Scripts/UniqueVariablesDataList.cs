using UnityEngine;
using System.Collections;
using System.Collections.Generic;

    [System.Serializable]
    public class UniqueVariablesDataList
    {
        public UniqueVariablesData[] items;
 
        public static UniqueVariablesDataList CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<UniqueVariablesDataList>(jsonString);
        }
    }