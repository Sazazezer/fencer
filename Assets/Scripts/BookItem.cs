using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookItem : MonoBehaviour {

  //  private PlayerController player;
    public GameObject healthEffect;
    public int healthBoost;
    public Canvas journal;

    private void Start()
    {
      //  player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void Use() {
        GameObject.FindObjectOfType<JournalCanvas>().Activate();
        Debug.Log("Beep");
    }
}
