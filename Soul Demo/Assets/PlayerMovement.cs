using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public LayerMask platformsLayerMask;
    public Rigidbody2D rigidbody2d;
    public BoxCollider2D boxCollider2d;

    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 16f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
        HandleMovement();
    }

    


    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }

    private void HandleMovement()
    {
        float moveSpeed = 8f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);

        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
            }
            else
            {
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            }
        }
    }

    
}
