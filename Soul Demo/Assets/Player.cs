using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player_ref;
    int health = 3;
    public Rigidbody2D RB;

    private void Awake()
    {
        player_ref = this;
        RB = transform.GetComponent<Rigidbody2D>();
    }
    public void TakeDamage()
    {
        RB.AddForce(new Vector2(-5000,500));
        health--;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Res.instance.Respawn();
            Destroy(this.gameObject);
        }
    }
}
