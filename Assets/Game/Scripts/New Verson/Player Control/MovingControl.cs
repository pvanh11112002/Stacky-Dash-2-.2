using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
// Hold the direction button to move along that direction
public class MovingControl : MonoBehaviour
{
    public static MovingControl Instance { get; private set; }
    
    [SerializeField] float speed = 10f;
    [SerializeField] Vector3 input = Vector3.zero;
    [SerializeField] bool up = false;
    [SerializeField] bool down = false;
    [SerializeField] bool left = false;
    [SerializeField] bool right = false;  
    [SerializeField] Transform footPrint;
    [SerializeField] GameObject skin;
    private float raycastLength = 1.75f;
    private RaycastHit hit;
    public bool getInput = false;
    public Animator anim;

    private void Awake()
    {
        Instance = this;
        
    }
    private void Update()
    {
        if(getInput)
        {
            PlayerInput();
            //FXManager.Instance.Play("Slide", footPrint);
        }    
            
    }
    private void PlayerInput()
    {       
        UpCheck();
        DownCheck();
        LeftCheck();
        RightCheck();
        input.x = Input.GetAxisRaw("Horizontal");
        input.z = Input.GetAxisRaw("Vertical");
        if(input.x != 0)
        {
            anim.SetTrigger("Run");
            if (input.x > 0 && right)
            {
                // Rẽ phải
                skin.transform.localEulerAngles = new Vector3(0, 90, 0);
                input = new Vector3(1, 0, 0);
                Move();
            }
            else if (input.x < 0 && left)
            {
                // Rẽ trái
                skin.transform.localEulerAngles = new Vector3(0, -90, 0);
                input = new Vector3(-1, 0, 0);
                Move();
            }
            input.z = 0;
        }
        if(input.z != 0)
        {
            anim.SetTrigger("Run");
            if (input.z > 0 && up)
            {
                // Lên trên
                skin.transform.localEulerAngles = new Vector3(0, 0, 0);
                input = new Vector3(0, 0, 1);
                Move();
            }
            else if(input.z < 0 && down)
            {
                // Xuống dưới
                skin.transform.localEulerAngles = new Vector3(0, 180, 0);
                input = new Vector3(0, 0, -1);
                Move();
            }
            input.x = 0;
        }
        else 
        {
            anim.SetTrigger("Idle");
        }
    }    
    private void Move()
    {
        if(input != Vector3.zero)
        {
            transform.position += new Vector3(input.x, input.y, input.z) * Time.deltaTime * speed;
            
        }        
    }
    private void UpCheck()
    {
        if (Physics.Raycast(footPrint.transform.position, Vector3.forward, out hit, raycastLength))
        {
            if (hit.collider.tag == "Eat" || hit.collider.tag == "Drop" || hit.collider.tag == "Used")
            {
                up = true;
            }
        }
        else
        {
            up = false;
        }
    }
    private void DownCheck()
    {
        if (Physics.Raycast(footPrint.transform.position, Vector3.back, out hit, raycastLength))
        {
            if (hit.collider.tag == "Eat" || hit.collider.tag == "Drop" || hit.collider.tag == "Used")
            {
                down = true;
            }
        }
        else
        {
            down = false;
        }
    }
    private void LeftCheck()
    {

        if (Physics.Raycast(footPrint.transform.position, Vector3.left, out hit, raycastLength))
        {
            if (hit.collider.tag == "Eat" || hit.collider.tag == "Drop" || hit.collider.tag == "Used")
            {
                left = true;
            }
        }
        else
        {
            left = false;
        }
    }
    private void RightCheck()
    {

        if (Physics.Raycast(footPrint.transform.position, Vector3.right, out hit, raycastLength))
        {
            if (hit.collider.tag == "Eat" || hit.collider.tag == "Drop" || hit.collider.tag == "Used")
            {
                right = true;
            }
        }
        else
        {
            right = false;
        }
    }
}

