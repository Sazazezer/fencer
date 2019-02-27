using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startPosition;
    public GameObject camera;
    public float parallaxEffect;


    void Start ()
    {
      //  startPosition = transform.position.x;
     //   length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update ()
    {
     //   float temp = (camera.transform.position.x * ( 1 - parallaxEffect));
     //   float distance = (transform.position.x * parallaxEffect + 1);
        transform.position = new Vector3(transform.position.x + parallaxEffect, transform.position.y, transform.position.z);

     /*   if (temp > startPosition + length) {
            startPosition += length;
        } else if (temp < startPosition - length) {
            startPosition -= length;
        }*/
    }
}