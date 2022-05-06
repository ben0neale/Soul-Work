using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public PlayerMovement pM;
    [SerializeField] Transform spawnPoint;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("hazard"))
        {
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            Player.transform.position = spawnPoint.position;
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
                GameObject Player = GameObject.FindGameObjectWithTag("Player");
                Player.transform.position = spawnPoint.position;
            }
        }



    }
}
