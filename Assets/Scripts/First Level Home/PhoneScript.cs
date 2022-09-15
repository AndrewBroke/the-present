using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class PhoneScript : MonoBehaviour
{
    public NPCConversation firstCheckConversation;
    public NPCConversation nextCheckConversation;
    public NPCConversation ringConversation;
    public AudioSource phoneRingAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.F) && Global.checkPhone == false)
        {
            Global.checkPhone = true;
            ConversationManager.Instance.StartConversation(firstCheckConversation);

            Invoke("Ring", 30);
        }
        else if (Input.GetKeyDown(KeyCode.F) && Global.checkPhone == true && Global.isRinging == false)
        {
            ConversationManager.Instance.StartConversation(nextCheckConversation);
        }
        else if(Input.GetKeyDown(KeyCode.F) && Global.isRinging == true)
        {
            ConversationManager.Instance.StartConversation(ringConversation);
            Global.wasRing = true;
        }
    }

    // Phone Ringing
    void Ring()
    {
        phoneRingAudio.Play();
        Global.isRinging = true;
    }
}
