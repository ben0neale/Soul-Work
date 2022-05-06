using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Camera Cam1;
    public Camera Cam2;
    public Camera liveCam;
    
    // Start is called before the first frame update
    private void Awake()
    {
        liveCam = Camera.allCameras[0];
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("camera"))
        {

            Debug.Log("colliding");
            Cam2.enabled = true;
            liveCam.enabled = false;

            liveCam = Camera.allCameras[0];

           
        }
    }
  
}
