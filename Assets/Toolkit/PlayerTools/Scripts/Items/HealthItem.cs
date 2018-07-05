using UnityEngine;
using System.Collections;

public class HealthItem : Collectible {

    public int itemID = 2;
    public GameObject player;
    public float healthIncrease = 2f;

    override protected void OnCollect(GameObject target){
        player.GetComponent<PlayerStats>().IncreaseHealth(healthIncrease); //abstraction needed
        }
    
}
