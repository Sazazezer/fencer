using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class SaveData {

    public string name;
    public int kills;

    public Vector3 playerPosition;
    public int sceneID;
    public Dictionary<string, Yarn.Value> dialogue;
}
