using UnityEngine;
using UnityEngine.UI;

public class ScrollPanel : MonoBehaviour
{
    // The variable to control where the scrollview 'looks' into its child elements.
    Vector2 scrollPosition;

    // The string to display inside the scrollview. 2 buttons below add & clear this string.
    string longString = "What difference are we talking about? If it's that a cult will use coercion tactics to get you to stay and then shame and shun you if you leave anyway then there are plenty of religions that still do that. Hell a lot of religions dont even let you really leave. As Dara Obriain says You could leave the Catholic Church and join the Taliban, and you'll still just be classed as being a really bad catholic'.And on top of that a lot of atheists may still be considered religious statistically and not even know it. Christian religions have been known to count their total number of followers based on the total number of people baptised into their religion (which makes sense right up until it doesn't). This means if you were baptised as a child, but then never went to church (except for weddings, funerals and the like) and were basically raised without any religious leanings you will still be counted towards the followers of their religion. This came up to me when a friend tried to have his baptism rescinded so he would no longer be counted as a member of the church. He politely went to the church about it and requested this, only to blocked again and again. Either the official he spoke to was completely befuddled about the idea of anyone officially leaving the church, claimed that there was no such method, or tried to pass him off to someone else. He believes he eventually succeeded in having them rescind it, but its not like they have to be open about how they obtain their numbers.";    public GameObject panel;

    void Update(){
       // longString = GameObject.Find("JournalText").GetComponent<Text>().text;
    }

    void OnGUI()
    {
        // Begin a scroll view. All rects are calculated automatically -
        // it will use up any available screen space and make sure contents flow correctly.
        // This is kept small with the last two parameters to force scrollbars to appear.
       // scrollPosition = GUILayout.BeginScrollView(
            //panel.transform.position, GUILayout.Width(panel.GetComponent<RectTransform>().sizeDelta.x), GUILayout.Height(panel.GetComponent<RectTransform>().sizeDelta.y))
                scrollPosition = new Vector2(panel.GetComponent<RectTransform>().sizeDelta.x, panel.GetComponent<RectTransform>().sizeDelta.y);

        // We just add a single label to go inside the scroll view. Note how the
        // scrollbars will work correctly with wordwrap.
        GUILayout.Label(longString);

        // Add a button to clear the string. This is inside the scroll area, so it
        // will be scrolled as well. Note how the button becomes narrower to make room
        // for the vertical scrollbar
        if (GUILayout.Button("Clear"))
            longString = GameObject.Find("JournalText").GetComponent<Text>().text;

        // End the scrollview we began above.
        GUILayout.EndScrollView();

        // Now we add a button outside the scrollview - this will be shown below
        // the scrolling area.
        if (GUILayout.Button("Add More Text"))
            longString += "\nHere is another line";
    }
}