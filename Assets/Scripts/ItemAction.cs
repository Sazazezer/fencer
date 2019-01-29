﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAction : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	public void Use (string _item, int _unique, int _slotNumber) {

        if(_item == "Sun"){
           Debug.Log("Sun has been used"); 

           player.GetComponent<BurnTree>().canBurn= 100 ;
           player.GetComponent<BurnTree>().keyInHand = _unique ;
           player.GetComponent<BurnTree>().itemSlotNumber = _slotNumber;
           player.GetComponent<BurnTree>().sunButton = gameObject;
        }
        if(_item == "Sword"){
           Debug.Log("Sword has been used"); 
        }

        if(_item == "GoldenBox"){
            GameObject instance = Instantiate(Resources.Load("House207DoorKey"), GameObject.Find("Player").transform) as GameObject;
            instance.transform.parent = null;
            instance.transform.position = GameObject.Find("Player").transform.position;
            //this.GetComponent<Item>().DestroyItem(this.GetComponent<Item>().slotNumber);
        }
		
	}
}
