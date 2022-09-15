using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ShelfScript : MonoBehaviour
{
    public NPCConversation shelfConv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ConversationManager.Instance.StartConversation(shelfConv);
        }
    }
}
