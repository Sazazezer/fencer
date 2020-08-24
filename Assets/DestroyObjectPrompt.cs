using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectPrompt : MonoBehaviour
{
	public GameObject referenceObject;
	public int referenceValue;
	public int destroyValue;
    // Start is called before the first frame update
    void Start()
    {
        referenceValue = referenceObject.GetComponent<HoleInTheMaking>().imageCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (referenceValue > destroyValue){
        	Destroy(gameObject);
        }
    }
}
