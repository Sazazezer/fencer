using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpItem : Collectible {

	override protected void OnCollect(GameObject target){

		
		PlayerPrefs.SetInt("WallStick",1);

		/*var equipBehavior = target.GetComponent<Equip> ();
		if(equipBehavior != null){
			equipBehavior.currentItem = itemID;*/
		}
}
