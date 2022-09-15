using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class PlayerMove : MonoBehaviour
{
    public int Speed = 1;
    public NPCConversation findMagazineConversation;
    public NPCConversation findMoneyConv;
    

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(!ConversationManager.Instance.IsConversationActive && 
            Global.canWalk == false && sr.enabled == true)
        {
            resumeMove();
        }

        if(Global.canWalk == false)
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetFloat("MovementX", 0f);
            return;
        }
        float move;

        move = Input.GetAxis("Horizontal") * Speed;
        animator.SetFloat("MovementX", Mathf.Abs(move));

        if(move < 0)
        {
            sr.flipX = false;
        }
        else if (move > 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = sr.flipX;
        }

        rb.velocity = new Vector2(move, 0);
    }

    public void stopMove()
    {
        animator.SetFloat("MovementX", 0f);
        Global.canWalk = false;
    }    

    public void resumeMove()
    {
        Global.canWalk = true;
    }

    public void Find()
    {
        if(Global.foundMoney)
        {
            ConversationManager.Instance.StartConversation(findMagazineConversation);
        }
        else
        {
            ConversationManager.Instance.StartConversation(findMoneyConv);
            Global.foundMoney = true;
        }
        
    }
}
