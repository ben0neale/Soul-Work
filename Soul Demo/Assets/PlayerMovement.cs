using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D RB;
    public int speed = 100;
    int jumpSpeed = 0;
    public Animator anim;
    bool grounded = true;
    float jumpTimer = 0f;


    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    private void Jump()
    {
        //if player is on the ground
        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpSpeed = 20;
                jumpTimer = .2f;
            }
        }
        if (jumpTimer > 0)
        {
            jumpTimer -= Time.deltaTime;
        }
        else
        {
            jumpSpeed = 0;
        }
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");

        RB.velocity = new Vector3(x * speed, jumpSpeed, 0);

        anim.SetFloat("speed", x);

        if (x < 0)
        {
            this.gameObject.transform.localScale = new Vector3(-.2f, .2f, 1);
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(.2f, .2f, 1);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            grounded = true;
            print("GROUND");
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            grounded = false;
            print("NO GROUND");
        }
    }
}
