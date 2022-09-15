using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundsColliderIgnore : MonoBehaviour
{
    public Collider2D[] colliders = { };
    // Start is called before the first frame update
    void Start()
    {
        Collider2D thisCollider = gameObject.GetComponent<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            Physics2D.IgnoreCollision(thisCollider, collider);
        }
        
    }
}
