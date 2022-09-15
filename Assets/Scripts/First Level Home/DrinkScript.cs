using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkScript : MonoBehaviour
{
    public Animator postProcessingAnimator;
    public AudioSource drinkSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            postProcessingAnimator.Play("Drink");
            drinkSound.Play();
        }
    }
}
