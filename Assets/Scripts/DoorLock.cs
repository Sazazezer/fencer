using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour {

    public bool isUnlockable = false;
    public GameObject player;
    public int lockNumber;
    public string doorName;
    public GameObject itemKill;
    public GameObject linkedItem;
    public bool locked = true;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isUnlockable==true){
        //    Debug.Log("Noooo");
            linkedItem.SetActive(true);
            //Destroy(gameObject);
            locked = false;
            this.GetComponent<DoorLockList>().UnlockDoorSave(lockNumber);
        }
		
	}

     private void OnTriggerStay2D(Collider2D other){

        if (other.tag == "Player" && player.GetComponent<UnlockDoor>().canBeUnlocked > 0){  
            if (player.GetComponent<UnlockDoor>().keyInHand == lockNumber){ 
                isUnlockable=true;
                itemKill = player.GetComponent<UnlockDoor>().keyButton;
                Debug.Log("Destroying key");
                if(itemKill != null){
                    itemKill.GetComponent<Item>().DestroyItem(player.GetComponent<UnlockDoor>().itemSlotNumber);                    
                }

                GameObject.FindObjectOfType<InventoryList>().SaveInventory();
            }
        }
    }
}
        