using DialogueEditor;
using UnityEngine;

public class Bus : MonoBehaviour
{

    DialogManager dialogManager;
    DirectorTimeline director;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        director = GameObject.Find("Timeline").GetComponent<DirectorTimeline>();
    }

    public void StartDialog()
    {
        NPCConversation dialog =transform.GetChild(0).GetComponent<NPCConversation>();
        dialogManager.StartDialog(dialog);
    }
}
