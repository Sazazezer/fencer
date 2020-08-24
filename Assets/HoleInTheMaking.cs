using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoleInTheMaking : MonoBehaviour
{

	public Sprite [] sprites;
	public int imageCount = 0;
	public int allItemsCollected = 0;
	public string [] digMessages;
    public bool messageShown = false;
    public int keepOnDigging = 0;
    public bool beginDig = false;
    public GameObject fadeCanvas;
    public GameObject fadePanelKill;
    private Fade fade;
    public bool canDig = true;
    public bool onDigSite = false;
    public GameObject deadBody;
    public GameObject player;
    public AudioClip digSound;
    public int bodyBuried = 0;
    //public GameObject spade;
   // public GameObject tarp;
   // public GameObject precious;
    // Start is called before the first frame update
    
    void Awake(){
        fadeCanvas = GameObject.Find("FadeCanvas");
        fadePanelKill = GameObject.Find("FadePanel");
    }

    void Start()
    {
    	Debug.Log(PlayerPrefs.GetInt("AlItemsCollected"));
        imageCount = PlayerPrefs.GetInt("HoleDug", 0);
        allItemsCollected = PlayerPrefs.GetInt("AlItemsCollected", 0 );
        bodyBuried = PlayerPrefs.GetInt("bodyBuried", 0);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[imageCount];
        Destroybody();
        GetComponent<AudioSource> ().playOnAwake = false;
        GetComponent<AudioSource> ().clip = digSound;
        if (allItemsCollected == 3){
            if (!beginDig){
                imageCount = 1;
                beginDig = true;
            }
           // precious = GameObject.Find("PreciousItemButton(Clone)");
            //tarp = GameObject.Find("ThirdhouseTarpButton(Clone)");
            //spade = GameObject.Find("SecondHouseSpadeButton(Clone)");
        }
    }

    // Update is called once per frame
    void Update()
    {
    	Debug.Log(keepOnDigging);
    	if (allItemsCollected == 3){
    		if (!beginDig){
    			imageCount = 1;
    			beginDig = true;
    		}

			if (bodyBuried == 0 && canDig && onDigSite && Input.GetButton("Fire1")){
				if(keepOnDigging < 100){
                    player.GetComponent<Dig>().digging = true;
					keepOnDigging++;
				} else {
		    		DigHole();	
				}
		    }    		
    	} else {
    	//	FindObjectOfType<TextBoxManager>().UpdateTextBox("A ceremony must be completed. Find what you need. A hole. A cover. A reminder.");
    	}

        
    }

    public void DigHole(){
    	if (imageCount < sprites.Length - 1){
	    	canDig = false;
	    	fadeCanvas.GetComponent<Fade>().MeFade();
            GetComponent<AudioSource> ().Play ();
	    	StartCoroutine(WaitForFadeIn());
	    	keepOnDigging = 0;
            Debug.Log("imagecount" + imageCount);
            Debug.Log("spritelength" + sprites.Length);
    	} else{
    		FindObjectOfType<TextBoxManager>().UpdateTextBox(digMessages[imageCount]);
            player.GetComponent<Dig>().digging = false;
            bodyBuried = 1;
            PlayerPrefs.SetInt("bodyBuried", 1);
    	}
    }


    void OnCollisionEnter2D(Collision2D other){
    	Debug.Log("Collide");
        onDigSite = true;
        if(messageShown == false){
            FindObjectOfType<TextBoxManager>().UpdateTextBox(digMessages[imageCount]);
            messageShown = true;            
        }
    }

    void OnCollisionExit2D(Collision2D other){
        onDigSite = false;
        if(messageShown == true){
            messageShown = false;            
        }
    }

    public IEnumerator WaitForFadeIn()
        {
        	yield return new WaitUntil(() => fadeCanvas.GetComponent<Fade>().screenIsDark == true);
        	imageCount++;
            GetComponent<AudioSource> ().Stop ();
    		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[imageCount];
    		fadeCanvas.GetComponent<Fade>().FadeMe();
    		PlayerPrefs.SetInt("HoleDug", imageCount);
            player.GetComponent<Dig>().digging = false;
            Destroybody();
    		StartCoroutine(ResumeDigging());

        }

    public IEnumerator ResumeDigging(){
    	yield return new WaitForSeconds(2);
    	FindObjectOfType<TextBoxManager>().UpdateTextBox(digMessages[imageCount]);
    	canDig = true;
    }

    void Destroybody(){
        if (deadBody != null){
            if (imageCount >= 8){

            PlayerPrefs.SetInt("OtherChasing", 1);
            //spade.GetComponent<Item>().DestroyItem(spade.GetComponent<Item>().slotNumber);                    
            //precious.GetComponent<Item>().DestroyItem(precious.GetComponent<Item>().slotNumber);  
            //tarp.GetComponent<Item>().DestroyItem(tarp.GetComponent<Item>().slotNumber);  
            //GameObject.FindObjectOfType<InventoryList>().SaveInventory();
            Destroy(deadBody);
            }

        }
    }
}
