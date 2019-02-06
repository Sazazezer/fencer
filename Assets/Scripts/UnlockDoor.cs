using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour {

    public int canBeUnlocked = 0;
    public GameObject lockInQuestion;
    public int keyInHand;
    public int itemSlotNumber;
    public GameObject keyButton;

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update(){
        if(canBeUnlocked > 0){
            canBeUnlocked--;
          //  Debug.Log(canBeUnlocked);
        }
    }

}
