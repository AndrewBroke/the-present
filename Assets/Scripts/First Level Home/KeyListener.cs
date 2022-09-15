using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.UI;

public class KeyListener : MonoBehaviour
{
    public GameObject pauseCanvas;
    public ConversationManager convManager;
    public GameObject[] images;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(ConversationManager.Instance.IsConversationActive)
            {
                ConversationManager.Instance.EndConversation();
                return;

            }

            // Убирание всплывающей картинки
            foreach (GameObject image in images)
            {
                Image img = image.GetComponent<Image>();
                if(img.color.a == 1)
                {
                    Animator anim = image.gameObject.GetComponent<Animator>();
                    anim.Play("FadeOut");
                    return;
                }
            }

            // Меню паузы
            if(pauseCanvas.activeSelf == false)
            {
                pauseCanvas.SetActive(true);
                Time.timeScale = 0f;
                AudioListener.pause = true;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                pauseCanvas.SetActive(false);
                Time.timeScale = 1f;
                AudioListener.pause = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) &&
            ConversationManager.Instance.IsConversationActive)
        {
            ConversationManager.Instance.SelectPreviousOption();
        }

        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) &&
            ConversationManager.Instance.IsConversationActive)
        {
            ConversationManager.Instance.SelectNextOption();
        }

        if((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) 
            && ConversationManager.Instance.IsConversationActive)
        {
            convManager.ScrollSpeed = 0.01f;

            ConversationManager.Instance.PressSelectedOption();
        }

        if ((Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Space))
            && ConversationManager.Instance.IsConversationActive)
        {
            convManager.ScrollSpeed = 1f;
        }
    }

    void ReturnSpeed()
    {
        convManager.ScrollSpeed = 1f;
    }
}
