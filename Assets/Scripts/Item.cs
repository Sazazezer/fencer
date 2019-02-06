using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    Key,
    Box
}

public class Item : MonoBehaviour {

    private Transform player;
    private Inventory inventory;
    public GameObject explosionEffect;
    public int slotNumber;
    public ItemType itemType;

    public GameObject actionObject;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void Use(string _use, int _unique) {
        actionObject.GetComponent<ItemAction>().Use(_use, _unique, slotNumber, itemType);
        if (inventory.slots[slotNumber].itemIndestructible == false){
            Debug.Log(inventory.slots[slotNumber]);            
            Debug.Log(inventory.slots[slotNumber].itemIndestructible);
            Instantiate(explosionEffect, player.transform.position, Quaternion.identity); //Game Design, do i need this?
            Debug.Log("Destroying key");
            DestroyItem(slotNumber);
        }

    }

    public void DestroyItem(int number){
            inventory.slots[number].itemName = "";
            inventory.slots[number].itemDescription = "";
            inventory.slots[number].itemObject = null;
            inventory.slots[number].KeyID = 0;
            inventory.slots[number].itemIndestructible = false;
            inventory.slots[number].prefabName = "";
            Debug.Log("Destroying key");
            Destroy(gameObject);
    }

}
