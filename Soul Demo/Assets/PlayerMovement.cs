using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D RB;
    public int speed = 100;
    public Animator anim;


    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");

        RB.velocity = new Vector3(x * speed, 0, 0);

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
}
