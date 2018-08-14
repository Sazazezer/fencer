using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class NextRoom {

  //   public string sceneName;
    // public float newDoorX;
   //  public float newDoorY;
     public int iAmDoor;
     public int iLeadTo;
     public bool roomTransition = false;
}
