using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVScript : MonoBehaviour
{
    public GameObject lights;
    public AudioSource TVOn;
    public AudioSource TVOff;
    public AudioSource TV;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // TV on
            if(lights.activeSelf == false)
            {
                TVOn.Play();
                TV.Play();
                lights.SetActive(true);
            }
            else
            {
                TVOff.Play();
                TV.Stop();
                lights.SetActive(false);
            }
        }
    }
}
