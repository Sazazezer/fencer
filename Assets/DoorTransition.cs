using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public enum DoorSide {
    leftdown = -50,
    rightup = 50,
}
public enum DoorDir{
    horizontal,
    vertical
}

public class DoorTransition : MonoBehaviour {
 
    public string goToScene;
    public int door;
    public int leadsTo;
    private NextRoom room;
    private string json;
    private string filename;
    public DoorSide doorSide;
    public DoorDir doorDir;
    static readonly string ROOM_MOVE = "room.json";

    public AudioClip doorOpenSound;
    private float doorOpenVolume = 0.5f;
    private AudioSource source;

    public GameObject fadeCanvas;
    public GameObject fadePanelKill;
    private Fade fade;
    public bool areaTransition = false;

    void Awake(){
        fadeCanvas = GameObject.Find("FadeCanvas");
        fadePanelKill = GameObject.Find("FadePanel");
    }

    void Start(){
        source = GetComponent<AudioSource>();
        doorOpenVolume = PlayerPrefs.GetFloat("GameSoundEffect",0.5f);
    }
 
    void OnTriggerStay2D(Collider2D other){
       if (areaTransition == false && Input.GetButtonUp("Up") && other.tag == "Player" ){
                if (this.GetComponent<DoorLock>().locked == false){
                    if(fadeCanvas != null){
                        GameObject.FindGameObjectWithTag("EffectsManager").GetComponent<AudioSource>().PlayOneShot(doorOpenSound,doorOpenVolume);
                        fadeCanvas.GetComponent<Fade>().MeFade();
                        StartCoroutine(WaitForFadeIn());   
                    } 
                    
                } 
        } else if (areaTransition == true){
            fadeCanvas.GetComponent<Fade>().MeFade();
            if (doorSide == DoorSide.leftdown){
                PlayerPrefs.SetInt("DoorSide",0);
            } else if (doorSide == DoorSide.rightup){
                PlayerPrefs.SetInt("DoorSide",1);
            }
            
            StartCoroutine(WaitForFadeIn());   
        }

            }
        
    public IEnumerator WaitForFadeIn()
        {
           yield return new WaitUntil(() => fadeCanvas.GetComponent<Fade>().screenIsDark == true);

                    room = new NextRoom() { 
                        iLeadTo = leadsTo,
                        roomTransition = true
                    };
                    json = JsonUtility.ToJson(room);
                    filename = Path.Combine(Application.streamingAssetsPath, ROOM_MOVE);
                    if (File.Exists(filename)){
                        File.Delete(filename);
                    }
                    File.WriteAllText(filename, json);
                    Application.LoadLevel(goToScene);
        }

}