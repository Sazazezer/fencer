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

        private string jsonData;
    
    public static Inventory CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<Inventory>(jsonString);
        }

    void Start(){
        highlightedSlot = 0;
        
    }

    void Update(){

  /*      for(int i = 0; i <5; i++){
            Debug.Log("Slot " + i + "is " + slots[i].itemIndestructible);
        }*/

        highlightedItem.transform.position =  slots[highlightedSlot].transform.position;
        itemTitlePanel.GetComponentInChildren<Text>().text = slots[highlightedSlot].itemName;
        itemDescriptionPanel.GetComponentInChildren<Text>().text = slots[highlightedSlot].itemDescription;
        itemHeld = slots[highlightedSlot].itemObject;
        itemItem = slots[highlightedSlot].itemName.ToString();
        itemUnique = slots[highlightedSlot].KeyID;

        if (bag.GetComponent<Canvas> ().enabled == true){


            if(highlightedSlot <= slots.Length-2){

                if (Input.GetButtonDown("Right")){
                    highlightedSlot++;

                }
            }

            if(highlightedSlot >= 1 ){

                if (Input.GetButtonDown("Left")){
                    highlightedSlot--;

                }
            }

            if(highlightedSlot > 7 ){
                if (Input.GetButtonDown("Up")){
                    highlightedSlot -= 8;
                }
            }

            if(highlightedSlot <= 7  ){
                if (Input.GetButtonDown("Down")){
                    highlightedSlot += 8;
                }
            }

            if(Input.GetButtonDown("Fire1")){
                itemHeld.GetComponent<Item>().Use(itemItem, itemUnique);
            }
        }

    }



    }


