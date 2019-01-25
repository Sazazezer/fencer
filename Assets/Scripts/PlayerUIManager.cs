using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour {


    public float health;
    public Text healthDisplay;
    public Canvas bag;
    public Canvas journal;
    public bool inJournal = false;
    public bool inBag = false;
    public GameObject puzzle;
    public bool inPuzzle = false;


    private void Start()
    {

        bag.GetComponent<Canvas> ().enabled = false;
        journal.GetComponent<Canvas> ().enabled = false;
        puzzle.GetComponent<Canvas> ().enabled = false;
    }

    private void Update()
    {

        healthDisplay.text = health.ToString();

        if (Input.GetButtonDown("Fire2")){
                GoToJournal();                    
        }

        if (Input.GetButtonDown("Fire3")){
                GoToBag();            
        }
        if (Input.GetButtonDown("Cancel")){
            BackToGame();
        }

        //ultimate save,load,reset area
        //save
        if (Input.GetKeyDown(KeyCode.F9)){
            SaveGameData();
        }
        //load
        if (Input.GetKeyDown(KeyCode.F10)){
            LoadGameData();
        }
        //reset
        if (Input.GetKeyDown(KeyCode.F12)){
            ResetGameData();
        }
    }

    public void GoToJournal() {
        if (inJournal == false){
            BackToGame();
            Destroy(GameObject.FindGameObjectWithTag("PuzzleScreen"));
            GameObject.FindObjectOfType<JournalCanvas>().Activate();
            Time.timeScale = 0f;
        //    Debug.Log("Into journal");
            inJournal = true;
        } else {
            BackToGame();
            GameObject.FindObjectOfType<JournalCanvas>().Deactivate();
            Time.timeScale = 1f;
          //  Debug.Log("Leave journal");
            inJournal = false;
        }

    }

    public void GoToPuzzle() {
        if (inPuzzle == false){
            BackToGame();
            inPuzzle = true;
        } else {
            BackToGame();
            inPuzzle = false;
        }

    }

    public void GoToBag() {
        if (inBag == false){
            BackToGame();
            Destroy(GameObject.FindGameObjectWithTag("PuzzleScreen"));
            GameObject.FindObjectOfType<Bag>().Activate();
            Time.timeScale = 0f;
            inBag = true;
        } else {
            BackToGame();
            GameObject.FindObjectOfType<Bag>().Deactivate();
            Time.timeScale = 1f;
            inBag = false;
        }

    }

    public void BackToGame() {
        GameObject.FindObjectOfType<Bag>().Deactivate();
        inJournal = false;
        GameObject.FindObjectOfType<JournalCanvas>().Deactivate();
        inBag = false;
        Time.timeScale = 1f; 
    }

    public void SaveGameData(){
        GameObject.FindObjectOfType<Serializer>().Save();
        GameObject.FindObjectOfType<InventoryList>().SaveInventory();
        //do items lists needs saving? No, each item gets saved as picked up.
    }

    public void LoadGameData(){
        GameObject.FindObjectOfType<Serializer>().Load();
        GameObject.FindObjectOfType<InventoryList>().LoadInventory();
        GameObject.FindObjectOfType<ItemList>().ItemCompile();
        GameObject.FindObjectOfType<JournalList>().JournalCompile();
    //    GameObject.FindObjectOfType<PuzzleUnlockList>().PuzzleLockCompile();

    }

    public void ResetGameData(){
        GameObject.FindObjectOfType<Serializer>().ResetGameData();
        GameObject.FindObjectOfType<InventoryList>().ResetInventory();
        GameObject.FindObjectOfType<ItemList>().ResetItems(); 
        GameObject.FindObjectOfType<JournalList>().ResetJournals(); 
     //   GameObject.FindObjectOfType<PuzzleUnlockList>().ResetDoors();
    }
}
