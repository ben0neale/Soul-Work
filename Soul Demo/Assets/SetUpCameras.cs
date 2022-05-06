using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCameras : MonoBehaviour
{
    public Camera Cam1;
    public Camera Cam2;
    // Start is called before the first frame update
    void Start()
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        Cam1.enabled = true;
        Cam2.enabled = false;
    }

   
}
