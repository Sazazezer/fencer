
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
	public void Use (string _item, int _unique, int _slotNumber, ItemType _itemType) {
        if(_itemType == ItemType.Key){   
           TryKeyInLock(_item, _unique, _slotNumber);
        }
        if(_item == "GoldenBox"){
            GameObject instance = Instantiate(Resources.Load("House209DoorKey"), GameObject.Find("Player").transform) as GameObject;
            instance.transform.parent = null;
            instance.transform.position = GameObject.Find("Player").transform.position;
            GameObject instance2 = Instantiate(Resources.Load("House207LockedSideboardKey"), GameObject.Find("Player").transform) as GameObject;
            instance2.transform.parent = null;
            instance2.transform.position = GameObject.Find("Player").transform.position;
            GameObject.FindObjectOfType<InventoryList>().SaveInventory();
            //this.GetComponent<Item>().DestroyItem(this.GetComponent<Item>().slotNumber);
        }
		
	}

    public void TryKeyInLock(string _itemName, int _keyIndex, int _fromSlot){

        if(player.GetComponent<UnlockDoor>().touchingDoor == true){
            Debug.Log(_itemName + "has been used"); 
            player.GetComponent<UnlockDoor>().canBeUnlocked= true ;
            player.GetComponent<UnlockDoor>().keyInHand = _keyIndex ;
            player.GetComponent<UnlockDoor>().itemSlotNumber = _fromSlot;
            player.GetComponent<UnlockDoor>().keyButton = gameObject; 
            GameObject.FindObjectOfType<PlayerUIManager>().BackToGame();            
        }
       
    }
}
