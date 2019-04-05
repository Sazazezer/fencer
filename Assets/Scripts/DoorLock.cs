using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorLock : MonoBehaviour {

    public bool isUnlockable = false;
    public bool failedToUnlock = false;
    public GameObject player;
    public int lockNumber;
    public string doorName;
    public GameObject itemKill;
    public GameObject linkedItem;
    public bool locked = true;
    public AudioClip doorUnlockSound;
    private float doorUnlockVolume = 0.5f;
    public AudioClip doorStillLockedSound;
    //private Text textBoxManager;

    private AudioSource source;


	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
        doorUnlockVolume = PlayerPrefs.GetFloat("GameSoundEffect",0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        if (isUnlockable==true){
            linkedItem.SetActive(true);
            locked = false;
            source.PlayOneShot(doorUnlockSound,doorUnlockVolume);
            GameObject.FindObjectOfType<DoorLockList>().UnlockDoorSave(lockNumber);
            isUnlockable = false;
            player.GetComponent<UnlockDoor>().canBeUnlocked = false;
        }

        if(failedToUnlock==true){
            source.PlayOneShot(doorStillLockedSound,doorUnlockVolume);
            failedToUnlock = false;
            player.GetComponent<UnlockDoor>().canBeUnlocked = false;
        }
		
	}

     private void OnTriggerStay2D(Collider2D other){

        if (other.tag == "Player" && player.GetComponent<UnlockDoor>().canBeUnlocked == true){  
            if (player.GetComponent<UnlockDoor>().keyInHand == lockNumber){ 
                isUnlockable=true;
                itemKill = player.GetComponent<UnlockDoor>().keyButton;
               // Debug.Log("Destroying key");
                if(itemKill != null){
                    FindObjectOfType<TextBoxManager>().UpdateTextBox("Unlocked.");
                    itemKill.GetComponent<Item>().DestroyItem(player.GetComponent<UnlockDoor>().itemSlotNumber);                    
                }

                GameObject.FindObjectOfType<InventoryList>().SaveInventory();
            } else {
                failedToUnlock = true;
                source.PlayOneShot(doorStillLockedSound,doorUnlockVolume);
                FindObjectOfType<TextBoxManager>().UpdateTextBox("This key isn't for that lock.");
            }
        } else if (other.tag == "Player" && Input.GetButtonUp("Up") && locked == true){
            source.PlayOneShot(doorStillLockedSound,doorUnlockVolume);
            FindObjectOfType<TextBoxManager>().UpdateTextBox("Locked.");
        }
    }

     private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            player.GetComponent<UnlockDoor>().touchingDoor = true;
        }
    }
     private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            player.GetComponent<UnlockDoor>().touchingDoor = false;
        }
    }
}
        