using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;
using UnityEngine.SceneManagement;

public class JournalList : MonoBehaviour {

/* 
 Look to list of journal entries, determine which has been found, and add them to the list.
 When button is clicked, displays the journal
*/
    public Canvas journal;
    public Button button;
    public GameObject panel;
    public GameObject highlightIcon;
    public GameObject textPanel;
    public int highlightSlot;
    public string jsonData;
    public string filename;
    public List<Button> buttons = new List<Button>();
    private int countDammit = 0;
    static readonly string JOURNAL_DATA = "msoel.json";
    public List <string> journalContents = new List<string>();
    public List <string> journalEntries = new List<string>();
    /*public Dictionary <string, string> journalEntry = new Dictionary<string, string>()
                    {
{"Controls","Left and right arrows to move. Up arrow to open doors. Z to interact. X to jump. C for Inventory. V for the Journals. Mission statement: Bury the body. You'll need three items before you can do so. Then you can try and leave."},
{"My journal","September 6th - Stuck indoors today. Rain is too heavy to go hunting in. Mary said I could probably still bag a few ducks but the rifle is likely to get jammed in these conditions. It cost too much to repair last time. We have plenty. Nothing to be concerned about. September 10th - The rain has not stopped. Eventually I had no choice but to go hunt. The conditions were still terrible. I managed to fire two shots before the damn gun locked up again. Two shots was more than enough to scare away any animals for the day. I've had to ask Keith to lend us some supplies. He's a good man. I said I owe him a favour. He laughed, said he'll be more than happy to collect on it. September 13th - Rain has finally calmed down. Rifle is still bust though. Mary tried fixing it but says it needs new parts. She says Jack can get them in for Tuesday next week. I'll have to ask Keith for help again at this rate. Semptember 19th - Keith asked to be paid back. Said I didn't have it yet. He's okay with it, but I know what he's like. He's a businessman. He wants the transaction complete so he can move on. Once Deer hunting season is back on again I'll have more than enough to pay him back. He might not be willing to wait that long. Septembe 22nd - Mary hasn't come back in two days. She's gone for a few days before but never like this. I've called the police. A man should be be coming around tomorrow to take a report."},
{"Dear Harry,","By the time you read this I'll be gone. I hate to end things in such a way but I can't go on like this. Nothing ever happens here, and while you seem fine with that, I can't go on living such a mundane life. I know I'm only good at fixing things but I feel I can do more than just spending my life fixing your equipment and keeping the house in order. Jack has picked me up, so you can be assured that I've not just run off with some other man. He's agreed to come back in a few days to pick up the rest of my things. Please don't give him any grief, Harry. They've been nothing but good friends to us over all these years. Please just let him pick up my stuff and go. Goodbye Harry. I wish things could have ended better between us. - Mary"},
{"Discarded journal", "If I knew I was to be tested like this I wouldn't have made so many deals. The shop isn't doing well. The big supermarkets have eaten up all my business, and I've been weak to those who still come into the shop. Allowed credit, allowed favours. I know it is a sin to covet wealth but now I have nearly nothing left and people still continue to take from me. The lenders called yesterday. I have fallen behind on the interest. I had been doing so well until that new store popped up out of nowhere. I can't compete on anything but my generosity, and that has only been abused. That Hunter fellow is the worst of them! With that sorry smile of his. If I can get him to pay me it'll fix a lot of my problems. If not... well I suppose I now know the code to his safe box. If I can get him out of the way, then whatever is in there will be worth it."},
{"Observations", "Number of customers this week - 17. Number of items unaccounted for - 8. Number of visits from Harry - 5. from Mary - 8. From Jack and Tony (always together) - 12. From Isaiah - 2. From Tiona - 20 (best customer, might be stealing though). Profits this week $27.86."},
{"Dormant Murders - News update", "Critics are skeptical, but news coming out this week hints the release of workHate Inc's newest work, The Dormant Murders, is set to be sometime in the next year. A murder investigation platformer, the game has players enter the small village of Askance to investigation the suicide/possible murder of a young woman. Players will access buildings like urban explorers, and search for clues relating to the case in a systematic manner, before being given a chance to solve the murder. The game is scheduled for a release date fo 2021. (oh god i am so bad at Marketing)"},
{"Product Recall Notice", "Regarding the sale of all Precious brand Lockboxes. Due to a fault in production, the code of all Lockboxes is set to the same default (2222) and cannot be changed. Customers are free to return their Lockboxes with a full refund. Receipt msut be provided."},
{"Note to Mary", "Hi Sue. This is Mary writing this, the only other person in the house. I placed the special item in the drawer with the weird combination lock on it. I figured it would be a good place. The combination is 2222, a perfect series of random numbers. Press these buttons if you ever want to find the special item."},
{"Benjamin's Journal","Day 1: Two new neighbors moved in next door today. Their names are Mary and Sue. They seem nice, though we only had a few seconds to chat. Spoke to EvilRod. He still refuses to pay his half of the gas bill. He says it is because he is evil, but I am not so sure. Day 2: Got into a further argument with EvilRod today. We shouted at each other for hours, which was most embarrassing. He is still refusing to pay his half of the gas bill. He says it is on religious grounds, that of him being an evil person. Afterwards I met up with Sue for a drink and told her about what was happening. It was nice to speak to someone about my relationship with Evilrod. She says that sometimes we just have to give up everything that makes us happy to accommodate the other person in our lives. She is a very wise person. I am glad to consider her a friend. Day 3: EvilRod has been quietly contemplating something all day today. I am still quite upset with him, but I will leave him alone no matter how much he stares menacingly at me. Mary came to the door today. She said she wishes to speak to me later about something of no major importance. She then left. I sure cannot wait to write in my journal again tomorrow."}
  };*/
                    
    // Use this for initialization
    void Awake(){

        filename = Path.Combine(Application.streamingAssetsPath, JOURNAL_DATA);
      //  if (SceneManager.GetActiveScene().buildIndex != 1){
            JournalCompile();
      //  }
        highlightSlot = 0;


    }

    void Update(){            



        if (journal != null){

            /*for(var k = 0 ; k < buttons.Count(); k++){
              //  Debug.Log("Button " + k + "is " + buttons[k]);
            }*/

            if(journal.GetComponent<JournalCanvas>().panelSelected == 0){
                if (buttons[highlightSlot]!= null){ //buttons.Count() > 0
                    highlightIcon.transform.position =  buttons[highlightSlot].transform.position;
                    textPanel.GetComponent<Image>().enabled = false;           
                }

              } else if(journal.GetComponent<JournalCanvas>().panelSelected == 1){
                 //   highlightIcon.transform.position =  textPanel.transform.position;
                    textPanel.GetComponent<Image>().enabled = true;
             }


            if (journal.GetComponent<Canvas> ().enabled == true){
                buttons[highlightSlot].GetComponent<ButtonClick>().SendToJournalTextPanel();

                if(journal.GetComponent<JournalCanvas>().panelSelected == 0){

                    if (Input.GetButtonDown("Right")){
                        journal.GetComponent<JournalCanvas>().panelSelected = 1;
                        highlightIcon.SetActive(false);
                       // highlightIcon.GetComponent <Image> ().color += new Color (0, 0, 0, -60);
                       // Debug.Log("Text selected");

                    }
                }
                if(journal.GetComponent<JournalCanvas>().panelSelected == 1){

                    if (Input.GetButtonDown("Left")){
                        journal.GetComponent<JournalCanvas>().panelSelected = 0;
                        highlightIcon.SetActive(true);
                      //  highlightIcon.GetComponent <Image> ().color += new Color (0, 0, 0, 60);
                      //  Debug.Log("List selected");
                    }
                }
                if(highlightSlot != 0 && journal.GetComponent<JournalCanvas>().panelSelected == 0){
                    if (Input.GetButtonDown("Up")){
                        GameObject.Find("JournalTextScrollbar").GetComponent<ScrollMovement>().ResetScrollbar();
                        highlightSlot--;
                    }
                }
                if(highlightSlot != buttons.Count()-1 && journal.GetComponent<JournalCanvas>().panelSelected == 0){
                    if (Input.GetButtonDown("Down")){
                        GameObject.Find("JournalTextScrollbar").GetComponent<ScrollMovement>().ResetScrollbar();
                        highlightSlot++;
                        Debug.Log("Hi");

                    }
                }



            }
        }
    }


    public void JournalCompile(){
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);

        }
        buttons.Clear();
        filename = Path.Combine(Application.streamingAssetsPath, JOURNAL_DATA);
        string jsonFromFile = File.ReadAllText(filename);
        JournalDataList list = JournalDataList.CreateFromJSON(jsonFromFile);
        countDammit = list.items.Count();
        Debug.Log("Count: " + countDammit);
        if (File.Exists(filename)){

            for (int i = 0; i < countDammit; i++){
                if (list.items[i].lockedAway == 1){
                    button.GetComponentInChildren<Text>().text = list.items[i].content;
                    
                    button.GetComponentInChildren<ButtonClick>().index = list.items[i].index;
                    button.GetComponentInChildren<ButtonClick>().content = list.items[i].content;
                    
                    
                      //  button.GetComponentInChildren<Text>().text = journalEntry.Keys.ElementAt(i);
                       // button.GetComponentInChildren<ButtonClick>().content = journalEntry.Keys.ElementAt(i);
                        //button.GetComponentInChildren<ButtonClick>().journal = journalEntry[journalEntry.Keys.ElementAt(i)];

                   // button.GetComponentInChildren<Text>().text = journalContents[i];
                   // button.GetComponentInChildren<ButtonClick>().content = journalContents[i];
                    button.GetComponentInChildren<ButtonClick>().journal = list.items[i].journal;
                   // button.GetComponentInChildren<ButtonClick>().journal = journalEntries[i];
                    var newButton = Instantiate(button, panel.transform);
                    buttons.Add(newButton);
                }
            }
        }
    }

    public void AddNewJournal(int _newIndex){
        Debug.Log("Adding" + _newIndex);
        string jsonFromFile = File.ReadAllText(filename);
        JournalDataList list = JournalDataList.CreateFromJSON(jsonFromFile);
        int newIndex = _newIndex;
        Debug.Log(newIndex);
        list.items[newIndex].lockedAway = 1;
        jsonData = JsonUtility.ToJson(list, true);

            if (File.Exists(filename)){
            //    File.Delete(filename);
            }

            File.WriteAllText(filename, jsonData);
            JournalCompile();
    }

    public void ResetJournals(){
       // filename = Path.Combine(Application.streamingAssetsPath, JOURNAL_DATA);

        string jsonFromFile = File.ReadAllText(filename);
        JournalDataList list = JournalDataList.CreateFromJSON(jsonFromFile);
        countDammit = list.items.Count();
         for (int i = 0; i < countDammit; i++){
                if (i != 0){
                    list.items[i].lockedAway = 0;
                }
            }
        jsonData = JsonUtility.ToJson(list,true);
        File.WriteAllText(filename, jsonData);
    }   

    public void HighlightSpecificSlot(int journalButton){

     /*   if(Input.GetButtonDown("Fire3")){*/
            int countButtons = 0;
            foreach (Button button in buttons){
                Debug.Log("Checking " + button.GetComponent<ButtonClick>().content + "and journal button" + journalButton + "and index is " + button.GetComponent<ButtonClick>().index);
                    if(journalButton == button.GetComponent<ButtonClick>().index){
                        GameObject.Find("JournalTextScrollbar").GetComponent<ScrollMovement>().ResetScrollbar();
                        highlightSlot = countButtons;
                        Debug.Log("Hightlighting button " + countButtons + " which should be " + button.GetComponent<ButtonClick>().content + " because i asked for " +  journalButton);
                    }
                    countButtons++;
                }
        




    }     
    
}