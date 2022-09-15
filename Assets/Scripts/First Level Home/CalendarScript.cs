using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class CalendarScript : MonoBehaviour
{
    public NPCConversation firstCheckCalendar;
    public NPCConversation nextCheckCalendar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && Global.checkCalendar == false)
        {
            ConversationManager.Instance.StartConversation(firstCheckCalendar);
            Global.checkCalendar = true;
            return;
        }

        if (Input.GetKeyDown(KeyCode.F) && Global.checkCalendar == true)
        {
            ConversationManager.Instance.StartConversation(nextCheckCalendar);
        }
    }
}
