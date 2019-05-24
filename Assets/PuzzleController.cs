using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using Yarn.Unity.Example;

public class PuzzleController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rigidBody;
    private Vector2 moveVelocity;
    public GameObject player;
    public GameObject dialogueContainer;
    public GameObject gameControlsContainer;

    private void Start()
    {
        StartCoroutine(Delay());
        player = GameObject.Find("Player");
        dialogueContainer = GameObject.Find("Dialogue Container");
        gameControlsContainer = GameObject.Find("Game Controls Container");
        rigidBody = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
    }

    public void Update(){

        if (player.activeInHierarchy == true){
            if (dialogueContainer != null)
                dialogueContainer.SetActive(false);

            // Show the game controls.
            if (gameControlsContainer != null) {
                gameControlsContainer.gameObject.SetActive(false);
            }
            player.SetActive(false);
            Debug.Log("kldsjahjrkjleh");

        }

            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput.normalized * speed;
            rigidBody.MovePosition(rigidBody.position + moveVelocity * Time.fixedDeltaTime);            
    
        if (Input.GetButtonDown("Fire3")){
                player.SetActive(true);
                player.GetComponent<PlayerUIManager>().BackToGame();
        }
    }

    public IEnumerator Delay(){
        yield return new WaitForSeconds(1);
    }
}
