using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {


    private Inventory inventory;
    public int index;
    public string itemName;
    public string itemDescription;
    public int KeyID;
    public GameObject itemObject;
    public bool itemIndestructible;
    public string prefabName;


    private void Start()
    {
        
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0) {
            inventory.items[index] = 0;
        }
     //   Debug.Log(itemName);
    }

    public void Cross() {

        foreach (Transform child in transform) {
            child.GetComponent<Spawn>().SpawnItem();
                            Debug.Log("Destroying key");
            GameObject.Destroy(child.gameObject);
        }
    }

}
