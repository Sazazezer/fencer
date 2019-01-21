using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupJournal : MonoBehaviour {

  //  private Inventory inventory;
    public GameObject itemButton;
    public GameObject effect;
    public string quickDescription;
    public string description;
    public int journalNumber;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            GameObject.FindObjectOfType<JournalList>().AddNewJournal(journalNumber);
            Destroy(gameObject);
        }

        
    }
}
