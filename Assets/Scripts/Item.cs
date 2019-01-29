using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    private Transform player;
    private Inventory inventory;
    public GameObject explosionEffect;
    public int slotNumber;

    public GameObject actionObject;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void Use(string _use, int _unique) {
        actionObject.GetComponent<ItemAction>().Use(_use, _unique, slotNumber);
        if (inventory.slots[slotNumber].itemIndestructible == false){
            Instantiate(explosionEffect, player.transform.position, Quaternion.identity); //Game Design, do i need this?
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
            Destroy(gameObject);
    }

}
