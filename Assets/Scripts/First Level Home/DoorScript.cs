using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DoorScript : MonoBehaviour
{
    public NPCConversation before;
    public NPCConversation after;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && Global.wasRing == false)
        {
            ConversationManager.Instance.StartConversation(before);
        }
        else if (Input.GetKeyDown(KeyCode.F) && Global.wasRing == true)
        {
            ConversationManager.Instance.StartConversation(after);
        }
        
    }
}
