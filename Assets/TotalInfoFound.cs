using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;

public class TotalInfoFound : MonoBehaviour {

    private string jsonData;
    private string filename;
    public Text totalInfoText;
    public Text secretInfoText;
    private int countDammit = 0;
    private int countUpFoundJournals = 0;
    private int percentageOfItemsFound;
    static readonly string JOURNAL_DATA = "msoel.json";
    // Use this for initialization
    void Start () {
        filename = Path.Combine(Application.streamingAssetsPath, JOURNAL_DATA);
        totalInfoText.text = "Total Evidence Found: " + JournalCountUp()+ "%";
     //   secretInfoText.text = "Secrets found...";
        //JournalCountUp();
    }

 
    public int JournalCountUp(){

        filename = Path.Combine(Application.streamingAssetsPath, JOURNAL_DATA);
        string jsonFromFile = File.ReadAllText(filename);
        JournalDataList list = JournalDataList.CreateFromJSON(jsonFromFile);
        countDammit = list.items.Count();
      //  Debug.Log("TotalNumberOfJournalItems = " + countDammit);
        if (File.Exists(filename)){
            for (int i = 0; i < countDammit; i++){
                if (list.items[i].lockedAway == 1){
                    countUpFoundJournals++;
                }
            }
        }
    //    Debug.Log("TotalNumberOfFoundJournalItems = " + countUpFoundJournals);
        percentageOfItemsFound = (countUpFoundJournals*100)/countDammit;
        return percentageOfItemsFound;
    }   
    
}