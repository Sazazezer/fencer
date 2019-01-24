using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBurn : MonoBehaviour {

    public bool isBurning = false;
    public GameObject player;
    public int lockNumber;
    public GameObject itemKill;
    public GameObject linkedItem;
    public bool locked = true;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isBurning==true){
            Debug.Log("Noooo");
            linkedItem.SetActive(true);
            //Destroy(gameObject);
            locked = false;
        }
		
	}

     private void OnTriggerStay2D(Collider2D other){

        if (other.tag == "Player" && player.GetComponent<BurnTree>().canBurn > 0){  
            Debug.Log("This happens");
            if (player.GetComponent<BurnTree>().keyInHand == lockNumber){ 
                isBurning=true;
                Debug.Log(player.GetComponent<BurnTree>().itemSlotNumber);
                Debug.Log(GameObject.Find("SunButton(Clone)").GetComponent<Item>());
                itemKill = player.GetComponent<BurnTree>().sunButton;
                itemKill.GetComponent<Item>().DestroyItem(player.GetComponent<BurnTree>().itemSlotNumber);//just figure this bit and you're done
            }
        }
    }
}
        