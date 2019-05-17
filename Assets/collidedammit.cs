using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collidedammit : MonoBehaviour {

void OnTriggerEnter2D(Collider2D other) 
{
    Debug.Log ("Triggered");
    this.GetComponent<Button>().Select();
}
}
