using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Inventory : MonoBehaviour {


    public int[] items;
    public Slot[] slots;
    public GameObject highlightedItem;
    public int highlightedSlot;
    public GameObject bag;
    public GameObject itemTitlePanel;
    public GameObject itemDescriptionPanel;
    public GameObject itemHeld;
    public string itemItem;
    public int itemUnique;
    public AudioClip itemMoveSound;
    private float itemMoveVolume = 0.5f;

    private AudioSource source;

    private string jsonData;
    
    public static Inventory CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<Inventory>(jsonString);
        }

    void Start(){
        highlightedSlot = 0;
        source = GetComponent<AudioSource>(); 
        itemMoveVolume = PlayerPrefs.GetFloat("GameSoundEffect",0.5f);       
    }

    void Update(){
        //highlightedItem.transform.position =  slots[highlightedSlot].transform.position;
        highlightedItem.transform.position =  new Vector3( slots[highlightedSlot].transform.position.x, slots[highlightedSlot].transform.position.y+20, slots[highlightedSlot].transform.position.z);
        itemTitlePanel.GetComponentInChildren<Text>().text = slots[highlightedSlot].itemName;
        itemDescriptionPanel.GetComponentInChildren<Text>().text = slots[highlightedSlot].itemDescription;
        itemHeld = slots[highlightedSlot].itemObject;
        itemItem = slots[highlightedSlot].itemName.ToString();
        itemUnique = slots[highlightedSlot].KeyID;

        if (bag.GetComponent<Canvas> ().enabled == true){


            if(highlightedSlot <= slots.Length-2){

                if (Input.GetButtonDown("Right")){
                    highlightedSlot++;
                    source.PlayOneShot(itemMoveSound,itemMoveVolume);

                }
            }

            if(highlightedSlot >= 1 ){

                if (Input.GetButtonDown("Left")){
                    highlightedSlot--;
                        source.PlayOneShot(itemMoveSound,itemMoveVolume);

                }
            }

            if(highlightedSlot > 7 ){
                if (Input.GetButtonDown("Up")){
                    highlightedSlot -= 8;
                    source.PlayOneShot(itemMoveSound,itemMoveVolume);
                }
            }

            if(highlightedSlot <= 7  ){
                if (Input.GetButtonDown("Down")){
                    highlightedSlot += 8;
                    source.PlayOneShot(itemMoveSound,itemMoveVolume);
                }
            }

            if(Input.GetButtonDown("Fire1")){
                if(itemHeld!=null){
                    itemHeld.GetComponent<Item>().Use(itemItem, itemUnique);                    
                }

            }
        }

    }



    }


