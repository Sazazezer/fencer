using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [System.Serializable]
    public class UniqueVariablesData
    {
        public int index;
        public string variableName;
        public int currentValue;
 
        public static UniqueVariablesData CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<UniqueVariablesData>(jsonString);
        }
    }