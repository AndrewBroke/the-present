using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameBtnScript : MonoBehaviour
{
    public GameObject fadeOutImage;

    public void newGame()
    {
        fadeOutImage.SetActive(true);
    }
}
