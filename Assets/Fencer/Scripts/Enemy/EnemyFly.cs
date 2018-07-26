using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : EnemyState {

    public float speed = 10f;

   private Rigidbody2D body2D;

    // Use this for initialization
    void Start () {
        body2D = GetComponent<Rigidbody2D> ();
    }
    
    // Update is called once per frame
    public void OnFly () {
        body2D.velocity = new Vector2 (transform.localScale.x * speed, 0) ;
    }
}
