using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour {


    public float health;
    public Text healthDisplay;

 //   public float speed;
  //  private Rigidbody2D rb;
   // private Animator anim;
//    private Vector2 moveVelocity;
    public Canvas bag;
    public Canvas journal;
    public bool inJournal = false;
    public bool inBag = false;
//   public Canvas puzzle;
    public GameObject puzzle;
    public bool inPuzzle = false;


    private void Start()
    {
    //    anim = GetComponent<Animator>();
     //   rb = GetComponent<Rigidbody2D>();
        bag.GetComponent<Canvas> ().enabled = false;
        journal.GetComponent<Canvas> ().enabled = false;
        puzzle.GetComponent<Canvas> ().enabled = false;
    }

    private void Update()
    {

        healthDisplay.text = health.ToString();

      /*  Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else {
            anim.SetBool("isRunning", false);
        }*/
        if (Input.GetButtonDown("Fire2")){
                GoToJournal();                    
        }

        if (Input.GetButtonDown("Fire3")){
                GoToBag();            
        }
        if (Input.GetButtonDown("Cancel")){
            BackToGame();
        }
        if (Input.GetButtonDown("Submit")){
            GameObject.FindObjectOfType<JournalList>().ResetJournals();
        //    GameObject.FindObjectOfType<PuzzleUnlockList>().ResetDoors(); REPLACE THIS
            GameObject.FindObjectOfType<ItemList>().ResetItems();
        }
    }

   /* private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }*/

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

   /* public void SetPuzzleCanvas(){
        puzzle = GameObject.FindObjectOfType<Canvas>();
    }*/
}
