using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameBtnScript : MonoBehaviour
{
    public void quitGame()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }
}
