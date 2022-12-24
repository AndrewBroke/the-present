using UnityEngine;
using DialogueEditor;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;
    float targetX;
    float targetY;
    bool isDialog = false;
    bool isTimeline = false;

    [SerializeField] private float speed = 20;

    [SerializeField] private Transform newPosition;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        ConversationManager.OnConversationStarted += ConversationStart;
        ConversationManager.OnConversationEnded += ConversationEnd;
    }


    void Update()
    {
        if (isDialog == false && isTimeline == false)
        {
            targetX = Input.GetAxis("Horizontal");
            targetY = Input.GetAxis("Vertical");
            Turn();
        }
        else
        {
            targetX = 0;
            targetY = 0;
            Turn();
        }
        
    }

    void FixedUpdate()
    { 
        if (targetX != 0 || targetY != 0)
            animator.SetBool("Move", true);
        else
            animator.SetBool("Move", false);

        rb.velocity = new Vector2(targetX * speed, targetY * speed);
    }

    //Разварачает аниацию в нуном направлении
    void Turn()
    {
        //Для избежения смены анимаций во время ходьбы по диагонали
        if (targetX > 0 && animator.GetCurrentAnimatorStateInfo(0).IsTag("Left_Right"))
        {
            sr.flipX = false;
            return;
        }
        else if (targetX < 0 && animator.GetCurrentAnimatorStateInfo(0).IsTag("Left_Right"))
        {
            sr.flipX = true;
            return;
        }
        else if (targetY > 0 && animator.GetCurrentAnimatorStateInfo(0).IsTag("Up"))
        {
            return;
        }
        else if (targetY < 0 && animator.GetCurrentAnimatorStateInfo(0).IsTag("Down"))
        {
            return;
        }

        //Вызывет триггер, если игрок только начинает двигаться в другом направлении 
        if (targetX > 0 && !animator.GetCurrentAnimatorStateInfo(0).IsTag("Left_Right"))
        {
            sr.flipX = true;
            animator.SetTrigger("TurnLeft");
        }
        else if (targetX < 0 && !animator.GetCurrentAnimatorStateInfo(0).IsTag("Left_Right"))
        {
            sr.flipX = false;
            animator.SetTrigger("TurnLeft");
        }
        else if (targetY > 0 && !animator.GetCurrentAnimatorStateInfo(0).IsTag("Up"))
        {
            animator.SetTrigger("TurnUp");
        }
        else if (targetY < 0 && !animator.GetCurrentAnimatorStateInfo(0).IsTag("Down"))
        {
            animator.SetTrigger("TurnDown");
        }
    }

    public void ChangePosition()
    {
        transform.position = newPosition.position;
    }

    private void ConversationStart()
    {
        isDialog = true;
    }

    private void ConversationEnd()
    {
        isDialog = false;
    }

    public void TimelineStart()
    {
        isTimeline = true;
    }
    public void TimelineEnd()
    {
        isTimeline = false;
    }
}