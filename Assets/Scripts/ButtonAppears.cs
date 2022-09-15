using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAppears : MonoBehaviour
{
    public GameObject button;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        button.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        button.SetActive(false);
    }
}
