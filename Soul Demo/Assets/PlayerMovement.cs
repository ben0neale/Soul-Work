using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public LayerMask platformsLayerMask;
    public Rigidbody2D rigidbody2d;
    public BoxCollider2D boxCollider2d;
    float dash_timer = .05f;
    bool dashing = false;

    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dashing = true;
        }
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 16f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
        HandleMovement();
        if (dashing)
        {
            dash();
        }
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
        if (!dashing)
        {
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

    void dash()
    {
        if (dash_timer > 0)
        {
            dashing = true;
            rigidbody2d.velocity = new Vector2(100, 0);
            dash_timer -= Time.deltaTime;
        }
        else
        {
            dashing = false;
            dash_timer = .05f;
        }
    }

    
}
