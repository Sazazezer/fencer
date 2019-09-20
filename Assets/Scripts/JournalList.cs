﻿using System;
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
    //public List <string> journalContents = new List<string>();
    //public List <string> journalEntries = new List<string>();
    public Dictionary <string, string> journalEntry = new Dictionary<string, string>()
                    {
        {"Mission Statement","Hello, and welcome to the wonderful demo world of solving murders. A man call Benjamin was killed, and it seems like the police have already made their decision on who the murderer was using evidence and stuff. But we disagree with this conclusion, and so we now seek to change it by entering the crime scene and touching all of the stuff until there is no stuff left to touch. Doing this we shall discover the truth. Go to the Town. Search everything every little. Important things will be kept in your journal. Unimportant things will be forgotten forever, unless you yourself write them down (you should probably get yourself a notepad]). When you're done just head out of town. From there you'll be given an opportunity to feel real smart. Remember to enjoy yourself. Otherwise nothing is worth it."},
        {"EvilRod's Journal","Day 1: Curses. My dear Benjamin is insisting that I disclose a sum of money to him in order to pay the gas bill. The cretin! Can he not see that I, EvilRod, have more important things to do that give him agreed sums of money in exchange for utilities. The fool. If only there was a way that I could be rid of him. Day 2: Unforgivable! My dear Benjamin still persists in his sound logical argument of me paying the gas bill as agreed upon in our notarised contract. Does he not realise that this is not possible for me. I am evil, and I am compelled to do evil for the evil's sake. One day I, EvilRod, shall make the fool pay."},
        {"Note to EvilRod","Now EvilRod. I want you to remember the code. It's important that you don't forget this, because I keep whispering it into your ear while you sleep and clearly this isn't enough to make you remember it. The code is 9582, the date of our anniversary. Please do not forget it this time."},
        {"EvilRod's Journal 2","Day 3: On quiet reflection I realise that I may have gone a little too far in my actions. Benjamin means well, and I care for him as part of our somewhat ambiguous relationship. I have decided. I shall change my ways. From now on I shall be known as... GoodRod. I have made a Lemon Meringue Pie in order to ask Ben to forgive me. I shall give it to him tomorrow. Though then I must leave. I still cannot pay him the gas bill, because I spent all my money on the ingredients to make the cake. I will travel up the mountain. It is for the best. Day 5: Mountain is cold. I do not know why I came up here. I want to go home. Am glad I reconciled with Benjamin. It was good to be good. I should continue to be good. Tomorrow I will go back home to Ben, and we can be good together. Day 6: Curses! Upon my return from the mountain I had found my dear Benjamin dead and the Cake either eaten or shoved inside his body. How did he die? There was no one else here that I noticed. Did I kill him, and simply forget about it? Did I not become GoodRod after all? Did I instead become SecretlyStillEvilRod. I will run away from this town. For I am a coward. Also the volcano will probably erupt soon. It is no longer dormant."},
        {"Sue's Journal","Day 1: First day moving into our new house. Woo! The town is old, but not as big as I figure town's should be (only three houses?). We met our new neighbours. Benjamin and EvilRod. Benjamin was very nice and I look forward to talking to him more. EvilRod seems a little... evil. I'm sure I must be imagining things. Day 2: I overheard an argument between Benjamin and Evilrod today. EvilRod was so scary. For a moment I feared for Ben's safety. It would be so bad for him to die, so soon after I had just met him. I spoke to Ben about it afterwards, and gave him some encouraging advice based upon my own relationship with Mary. I was glad to be of help. Day 3: Sue confronted me today for speaking to Benjamin with her around. She doesn't like it, but I told her it was fine. I will not repeat the mistakes from our shared past. I reassured her that my special item has been locked up in its chest this whole time. Day 4: Forgot to write in my journal today. Silly me. Day 5: Oh no. It's so horrible. When I got to Benjamin's house today, I found him dead in his chair. There was a hole cut into his body, and the hole was stuffed full of pie. Mary called the police quickly and we saw that the pie had been made in EvilRod's kitchen. He must have been the killer, but he is nowhere to be seen. I will miss Ben deeply. The pie was delicious. Day 6: Me and Mary are leaving town today. We decided it was the best thing to do considering what had happened. The whole thing has been a terrible first impression, and it is lonely now that no one else lives here."},
        {"Mary's Journal","Day 1: Moved into the new house today. Sue is excited. I must make sure to protect her if we are to get along with the rest of the townsfolks. We met Benjamin and Evilrod, our neighbors. They seem nice. Well, Benjamin is anyway. We caught them at a bad time. They were arguing about something. Day 2: The argument continued all night, and I had trouble sleeping because of it. I spent today unpacking boxes and setting up ornaments. I had to repolish my collection of antique knives. While I was doing so I saw Benjamin speaking with Sue. I must warn her to be careful around new people. Day 3: I spoke to Sue today and told her to stay away from Ben unless I was near. Men are a cowardly and superstitious lot, and she could end up in a dangerous situation all over again. Sue told me it was nothing."},
        {"Mary's Journal 2","Day 4: I spoke to Ben and asked him not to speak to Sue unless I am around. I can't tell him why, but even so his response was very rude. He seems to misunderstand why I would tell him this. It's annoying that he makes such assumptions. I have to protect sue at any cost. Day 5: Sue found Ben's body today. It looks like he had been killed with a lemon meringue pie that was shoved through his ribcage. I called the police after ensuring everything was tidied up. The police came over and shared my conclusion that EvilRod must be the killer. It looks like Evilrod has escaped though. We opted to share the leftover pie with the policeman. He was very nice. Day 6: On the policeman's suggestion we have opted to leave town. I probably would have anyway. Moving our stuff again was annoying, so we've opted to dump it outside. The volcano will take care of it. I am glad that Sue is safe. Together we will be safe forever."},
        {"Note to Mary","Hi Sue. This is Mary writing this, the only other person in the house. I placed the special item in the drawer with the weird combination lock on it. I figured it would be a good place. The combination is 2222, a perfect series of random numbers. Press these buttons if you ever want to find the special item."},
        {"Benjamin's Journal","Day 1: Two new neighbors moved in next door today. Their names are Mary and Sue. They seem nice, though we only had a few seconds to chat. Spoke to EvilRod. He still refuses to pay his half of the gas bill. He says it is because he is evil, but I am not so sure. Day 2: Got into a further argument with EvilRod today. We shouted at each other for hours, which was most embarrassing. He is still refusing to pay his half of the gas bill. He says it is on religious grounds, that of him being an evil person. Afterwards I met up with Sue for a drink and told her about what was happening. It was nice to speak to someone about my relationship with Evilrod. She says that sometimes we just have to give up everything that makes us happy to accommodate the other person in our lives. She is a very wise person. I am glad to consider her a friend. Day 3: EvilRod has been quietly contemplating something all day today. I am still quite upset with him, but I will leave him alone no matter how much he stares menacingly at me. Mary came to the door today. She said she wishes to speak to me later about something of no major importance. She then left. I sure cannot wait to write in my journal again tomorrow."}
    };
                    
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
                    /*button.GetComponentInChildren<Text>().text = list.items[i].content;*/
                    
                    button.GetComponentInChildren<ButtonClick>().index = list.items[i].index;
                    /*button.GetComponentInChildren<ButtonClick>().content = list.items[i].content;*/
                    
                    
                        button.GetComponentInChildren<Text>().text = journalEntry.Keys.ElementAt(i);
                        button.GetComponentInChildren<ButtonClick>().content = journalEntry.Keys.ElementAt(i);
                        button.GetComponentInChildren<ButtonClick>().journal = journalEntry[journalEntry.Keys.ElementAt(i)];

                    //button.GetComponentInChildren<Text>().text = journalContents[i];
                   // button.GetComponentInChildren<ButtonClick>().content = journalContents[i];
                    /*button.GetComponentInChildren<ButtonClick>().journal = list.items[i].journal;*/
                   // button.GetComponentInChildren<ButtonClick>().journal = journalEntries[i];
                    var newButton = Instantiate(button, panel.transform);
                    buttons.Add(newButton);
                }
            }
        }
    }

    public void AddNewJournal(int _newIndex){

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