using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class TableScript : MonoBehaviour
{
    public Animator characterAnimator;
    public NPCConversation findMoneyConv;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            characterAnimator.SetTrigger("Search");
        }
    }
}
