using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Res : MonoBehaviour
{
    public static Res instance;

    public Transform resPoint;
    public GameObject playerPre;

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        Instantiate(playerPre, resPoint.position, Quaternion.identity);
    }
}
