using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{

    private int order;
    private SpriteRenderer sr;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        order = sr.sortingOrder;

        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.y > transform.position.y)
        {
            sr.sortingOrder = order + 10;
        }
        if (player.position.y < transform.position.y)
        {
            sr.sortingOrder = order;
        }
    }
}
