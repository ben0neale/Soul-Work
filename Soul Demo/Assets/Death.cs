using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public PlayerMovement pM;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("hazard"))
        {
            
            Destroy(gameObject);
            Res.instance.Respawn();
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            if (pM.isDashing)
            {
                GameObject Enemy = GameObject.FindGameObjectWithTag("enemy");
                Destroy(Enemy);
            }
            else
            {
                Destroy(gameObject);
                Res.instance.Respawn();
            }
        }



    }
}
