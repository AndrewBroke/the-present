using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPlayer : MonoBehaviour
{

    private GameObject fButton;
    private GameObject coll;

    // Start is called before the first frame update
    void Start()
    {
        fButton = GameObject.Find("FButton");
        fButton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && fButton.activeSelf == true)
        {
            fButton.SetActive(false);
            NPCConversation conversation = coll.transform.GetChild(0).GetComponent<NPCConversation>();
            ConversationManager.Instance.StartConversation(conversation);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dialog")
        {
            coll = collision.gameObject;
            fButton.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dialog")
        {
            coll = null;
            fButton.SetActive(false);
        }
    }


}
