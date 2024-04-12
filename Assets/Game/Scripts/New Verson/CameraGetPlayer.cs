using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGetPlayer : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        cam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
}
