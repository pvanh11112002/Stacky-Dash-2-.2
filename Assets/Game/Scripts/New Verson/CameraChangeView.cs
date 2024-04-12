using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeView : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera defaultCam;
    [SerializeField] CinemachineVirtualCamera secCam;

    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            defaultCam.gameObject.SetActive(false);
            secCam.gameObject.SetActive(true);
        }
        
    }
}
