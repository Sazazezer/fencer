using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLock : MonoBehaviour {

    public string puzzleLockAnswer;
    public bool puzzleLockMaxDigitedSet = true;
    public int puzzleLockTotalDigits = 10;
    public int puzzleLockIndex;
    public GameObject player;
    public GameObject puzzlePrefab;
    public GameObject puzzle; //doesn't need filling in
    public GameObject canvas;
    public GameObject unlockedItem;
    public bool locked = true;
    public Sprite unlockedSprite;

    void Start(){
        if (locked == false){
            SwitchUnlockSprite();
        }
    }
    public void OnTriggerStay2D(Collider2D other){
     //   if (Input.GetButtonUp("Jump") && other.tag == "Player"){

       //     UsePuzzleLock();
      //  }
    }

    public void UsePuzzleLock(){
        puzzle = Instantiate(puzzlePrefab,canvas.transform);
        player.GetComponent<PlayerUIManager>().puzzle = puzzle;
        puzzle.GetComponent<PuzzleCanvas>().Activate();
        puzzle.GetComponent<PuzzleBackend>().puzzleAnswer = puzzleLockAnswer;
        puzzle.GetComponent<PuzzleBackend>().GetMaxDigits();
        puzzle.GetComponent<PuzzleBackend>().linkedObject = gameObject;
    }

    public void PuzzleUnlock () {
        puzzle.GetComponent<PuzzleCanvas>().Deactivate();
        this.GetComponent<PuzzleLockList>().UnlockPuzzleSave(puzzleLockIndex);

        if (unlockedItem != null){
            unlockedItem.SetActive(true);            
        }
        locked = false;
        SwitchUnlockSprite();
    }

    public void SwitchUnlockSprite(){
        if (unlockedSprite!=null){
            gameObject.GetComponent<SpriteRenderer>().sprite = unlockedSprite;
        }     
    }
}
