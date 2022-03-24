using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("hazard"))
        {
            Destroy(gameObject);
            Res.instance.Respawn();
        }

    }
}
