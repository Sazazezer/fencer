
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Yarn.Unity.Example;
using Yarn.Unity;

public class PlayerUIManager : MonoBehaviour {


    public float health;
    public Text healthDisplay;
    public Canvas bag;
    public Canvas journal;
    public bool inJournal = false;
    public bool inBag = false;
    public GameObject puzzle;
    public bool inPuzzle = false;
    public bool loadDialogueData = false;
    public bool dialogueIsRunning = false;


    private void Start()
    {
        bag.GetComponent<Canvas> ().enabled = false;
        journal.GetComponent<Canvas> ().enabled = false;
       // puzzle.GetComponent<Canvas> ().enabled = false;

        if (SceneManager.GetActiveScene().buildIndex != 1 || SceneManager.GetActiveScene().buildIndex != 7 || SceneManager.GetActiveScene().buildIndex != 5){
            LoadGameData(); //time to get this working in some way!
            Debug.Log("I loaded Game Data.");
            GameObject.FindObjectOfType<LocationList>().Save();
        }


    }

    private void Update()
    {  Debug.Log(dialogueIsRunning);
        if (loadDialogueData ==false){ //because things break?
            loadDialogueData = true;
            Scene currentScene = SceneManager.GetActiveScene ();
            string sceneName = currentScene.name;
            if (sceneName == "OpeningScene"){
                GameObject.FindObjectOfType<DialogueList>().ResetDialogue();
                GameObject.FindObjectOfType<DialogueList>().Save();
            }
            GameObject.FindObjectOfType<DialogueList>().LoadFromJson();

        }



    }

    public void GoToJournal() {

            if (inJournal == false && dialogueIsRunning == false){
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
        if (inPuzzle == false && dialogueIsRunning == false){
            BackToGame();
            inPuzzle = true;
        } else {
            BackToGame();
            inPuzzle = false;
        }

    }

    public void GoToBag() {
        if (inBag == false && dialogueIsRunning == false){
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
        if(inPuzzle==true){
        GameObject.FindObjectOfType<PuzzleCanvas>().Deactivate();          
        }

        inPuzzle = false;
        inBag = false;
        Time.timeScale = 1f; 
    }

    public void SaveGameData(){
        //this is the complex one. Saves should only go through at specified points
        Debug.Log("Game Data Saving");
        GameObject.FindObjectOfType<LocationList>().Save();
        GameObject.FindObjectOfType<InventoryList>().SaveInventory();
        //SaveItems - Done when item is picked up CONFIRMED?
        //SaveJournals - Done when journal is picked up CONFIRMED?
        //Save PuzzleLock- Done when lock is completed CONFIRMED?
        //SaveUniques - Done at the time of the action CONFIRMED?
        Debug.Log("Game Data Saved");
    }

    public void LoadGameData(){
        Debug.Log("Game Data Loading"); //Loaded on Continue, when the player starts in the current room. Should only need to be loaded once.
     //  GameObject.FindObjectOfType<LocationList>().Load();
                Debug.Log("Location Data Loaded");
        GameObject.FindObjectOfType<InventoryList>().LoadInventory();
                Debug.Log("Inventory Data Loaded");
        GameObject.FindObjectOfType<ItemList>().ItemCompile();
                Debug.Log("Items Data Loaded");
        GameObject.FindObjectOfType<JournalList>().JournalCompile();
                Debug.Log("Journal Data Loaded");
        GameObject.FindObjectOfType<PuzzleLockList>().PuzzleLockCompile();
                Debug.Log("Puzzle Data Loaded");
   //     GameObject.FindObjectOfType<UniqueVariablesList>().ResetUniqueVariables(); Need to make save and load things
                Debug.Log("Unique Data Loaded");
                Debug.Log("Dialogue Data Loaded");// Never put dialogue save here. Loads through Update.

        Debug.Log("Game Data Loaded");
    }

    public void ResetGameData(){
        //Game data should only be reset in the opening room, when the player has started a new game
        Debug.Log("Game Data Resetting");
        GameObject.FindObjectOfType<LocationList>().ResetGameData();
                Debug.Log("Game Data Reset");
        GameObject.FindObjectOfType<InventoryList>().ResetInventory();
                Debug.Log("Inventory Data Reset");
        GameObject.FindObjectOfType<ItemList>().ResetItems(); 
                Debug.Log("Item Data Reset");
        GameObject.FindObjectOfType<JournalList>().ResetJournals();
                Debug.Log("Journal Data Reset");
        GameObject.FindObjectOfType<PuzzleLockList>().ResetPuzzleLocks();
                Debug.Log("Puzzle Data Reset");
      //  GameObject.FindObjectOfType<UniqueVariablesList>().ResetUniqueVariables();
                Debug.Log("Unique Data Reset");//i don't need this at the moment
        GameObject.FindObjectOfType<DoorLockList>().ResetDoorLocks(); 
                Debug.Log("Door Data Reset"); 
        GameObject.FindObjectOfType<DialogueList>().ResetDialogue();
                Debug.Log("Dialogue Data Reset");
            PlayerPrefs.SetInt("GameHasStarted",0);

    //ResetUniques
    }

    public void SaveDialogue(){
        GameObject.FindObjectOfType<DialogueList>().Save();
    }
}
