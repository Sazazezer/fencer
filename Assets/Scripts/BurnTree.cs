using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnTree : MonoBehaviour {

    public int canBurn = 0;
    public GameObject treeInQuestion;
    public int keyInHand;
    public int itemSlotNumber;
    public GameObject sunButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update(){
        if(canBurn > 0){
            canBurn--;
            Debug.Log(canBurn);
        }
    }

}
