using UnityEngine;
using System.Collections;

public class PowerUpFlower : Collectible {

	public int itemID = 1;
	public GameObject projectilePrefab;

	override protected void OnCollect(GameObject target){

		var equipBehavior = target.GetComponent<Equip> ();
		if(equipBehavior != null){
			equipBehavior.currentItem = itemID;
		}

		var shootBehavior = target.GetComponent<FireProjectile> ();
		if (shootBehavior != null) {
			shootBehavior.projectilePrefab = projectilePrefab;
		}
	}
}
