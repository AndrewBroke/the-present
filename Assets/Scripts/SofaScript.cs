using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaScript : MonoBehaviour
{
    public GameObject[] sofaBtns = { };
    public SpriteRenderer Character;
    public AudioSource sittingSound;

    public Animator sofaAnimator;
    // Start is called before the first frame update
    void Start()
    {
        Seat();
    }

    // Update is called once per frame
    void Update()
    {
        // Start seating
        if(Input.GetKeyDown(KeyCode.F) && sofaAnimator.GetBool("Seat") == false)
        {
            Seat();
            return;
        }

        // End seating
        if (Input.GetKeyDown(KeyCode.F) && sofaAnimator.GetBool("Seat") == true)
        {
            Wake();
        }
    }

    public void Seat()
    {
        sittingSound.Play();
        Character.enabled = false;
        Global.canWalk = false;
        

        foreach (GameObject btn in sofaBtns)
        {
            btn.SetActive(true);
        }

        sofaAnimator.SetBool("Seat", true);
    }

    public void Wake()
    {
        sittingSound.Play();
        Character.enabled = true;
        Global.canWalk = true;

        foreach (GameObject btn in sofaBtns)
        {
            btn.SetActive(false);
        }


        sofaAnimator.SetBool("Seat", false);
        sofaAnimator.SetBool("Grab", false);
        sofaAnimator.SetBool("Put", false);
    }
}
