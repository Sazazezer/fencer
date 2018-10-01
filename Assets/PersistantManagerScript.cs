
using UnityEngine;

public class PersistantManagerScript : MonoBehaviour {

    public static PersistantManagerScript Instance {get; private set;}

    public int Value;

    private void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}
