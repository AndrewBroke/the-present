using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterFadeOut : MonoBehaviour
{
    public string sceneName;

    private bool isLoading = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isLoading)
        {
            if(SceneManager.GetSceneByName(sceneName).isLoaded)
            {
                Scene curScene = SceneManager.GetActiveScene();
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
                SceneManager.UnloadSceneAsync(curScene);
            }
        }
    }

    public void loadScene()
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        isLoading = true;
    }
}
