using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseCanvas;
    public void Resume()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }
}
