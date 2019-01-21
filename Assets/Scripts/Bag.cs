using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour {

//    bool isClosed;
    public GameObject bag;

    public void Activate(){
     //   Debug.Log("Boobp");
        bag.GetComponent<Canvas> ().enabled = true;

        
    }

    public void Deactivate(){
     //   Debug.Log("Beeb");
        bag.GetComponent<Canvas> ().enabled = false;
    }

}
