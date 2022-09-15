using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleScript : MonoBehaviour
{
    public Animator sofaAnimator;
    public AudioSource pickUpSound;
    public AudioSource setDownSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // The key Q makes character grab the bottle and then seat with it
        // If bottle in the hand it makes character put in on the table

        if(Input.GetKeyDown(KeyCode.Q) && sofaAnimator.GetBool("Grab") == false)
        {
            sofaAnimator.SetBool("Grab", true);
            sofaAnimator.SetBool("Put", false);
            pickUpSound.Play();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Q) && 
            sofaAnimator.GetBool("Put") == false && 
            sofaAnimator.GetBool("Grab") == true)
        {
            sofaAnimator.SetBool("Put", true);
            sofaAnimator.SetBool("Grab", false);
            setDownSound.Play();
            return;
        }
    }
}
