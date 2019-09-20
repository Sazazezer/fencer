using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MoveToNextRoom : MonoBehaviour {
 
    public string goToScene;
    public int door;
    public int leadsTo;
    private NextRoom room;
    private string json;
    private string filename;
    public DoorSide doorSide;
    public DoorDir doorDir;
    static readonly string ROOM_MOVE = "room.json";

    public GameObject fadeCanvas;
    public GameObject fadePanelKill;
    private Fade fade;

    void Awake(){ 
        fadeCanvas = GameObject.Find("FadeCanvas");
        fadePanelKill = GameObject.Find("FadePanel");
    }
 
    void OnCollisionEnter2D(Collision2D other){
                    if(fadeCanvas != null){
                        fadeCanvas.GetComponent<Fade>().MeFade();
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