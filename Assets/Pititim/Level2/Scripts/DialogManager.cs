using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public void ChangeNextDialog(GameObject nextDialog)
    {
        nextDialog.transform.SetSiblingIndex(0);
    }

    public void CallDialogAfter10Seconds(NPCConversation conversation)
    {
        StartCoroutine(wait(conversation));
    }

    IEnumerator wait(NPCConversation dialog)
    {
        yield return new  WaitForSeconds(10);
        ConversationManager.Instance.StartConversation(dialog);
    }

    public void StartDialog(NPCConversation dialog)
    {
        ConversationManager.Instance.StartConversation(dialog);
    }
}