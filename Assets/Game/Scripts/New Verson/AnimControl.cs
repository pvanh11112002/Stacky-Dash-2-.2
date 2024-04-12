using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject skin;
    void Update()
    {
        //skin.transform.position = transform.position;
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            //anim.ResetTrigger("Run");
            anim.SetTrigger("Idle");
        }  
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            //anim.ResetTrigger("Idle");
            anim.SetTrigger("Run");
        }            
    }
}
