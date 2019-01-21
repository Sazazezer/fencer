using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunItem : MonoBehaviour {

    private Transform player;
    private Inventory inventory;
    public GameObject explosionEffect;
    public int slotNumber;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void Use() {
        Instantiate(explosionEffect, player.transform.position, Quaternion.identity);
        inventory.slots[slotNumber].itemName = "";
        Destroy(gameObject);
    }

    public void Update(){
        Debug.Log("sunitem says: " + slotNumber);

    }

}
