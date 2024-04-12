using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
// Press only 1 time to move along to the direction of input's axis
public class MovingControl2 : Singleton<MovingControl2>
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] GameObject skin;
    public Rigidbody rb;
    public bool upCanMove;
    public bool downCanMove;
    public bool leftCanMove;
    public bool rightCanMove;
    public float raycastLength = 1f;
    public Vector3 moveDirection;
    public float moveSpeed = 5f;
    public GameObject neck;
    public bool isMoving = false;
    public Animator anim;
    public bool getInput = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        #region Draft
        //// Luôn check có thể di chuyển trái phải trên dưới hay không
        //upCanMove = UpCheck();
        //downCanMove = DownCheck();
        //leftCanMove = LeftCheck();
        //rightCanMove = RightCheck();
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        //if (horizontalInput != 0)
        //{
        //    if (horizontalInput > 0)
        //    {
        //        // Rẽ phải
        //        if (rightCanMove)
        //        {
        //            moveDirection = new Vector3(1, 0, 0);
        //            rb.velocity = moveDirection * moveSpeed;
        //        }
        //        else
        //        {
        //            rb.velocity = Vector3.zero;
        //        }

        //    }
        //    else if (horizontalInput < 0)
        //    {
        //        // Rẽ trái
        //        if (leftCanMove)
        //        {
        //            moveDirection = new Vector3(-1, 0, 0);
        //            rb.velocity = moveDirection * moveSpeed;
        //        }
        //        else
        //        {
        //            rb.velocity = Vector3.zero;
        //        }
        //    }
        //}
        //if (verticalInput != 0)
        //{
        //    if (verticalInput > 0)
        //    {
        //        // Lên trên
        //        //moveDirection = new Vector3(0, 0, 1);
        //        //rb.velocity = moveDirection * moveSpeed;
        //        if (upCanMove)
        //        {
        //            moveDirection = new Vector3(0, 0, 1);
        //            rb.velocity = moveDirection * moveSpeed;
        //        }
        //        else
        //        {
        //            rb.velocity = Vector3.zero;
        //        }
        //    }
        //    else if (verticalInput < 0)
        //    {
        //        // Xuống dưới
        //        if (downCanMove)
        //        {
        //            moveDirection = new Vector3(0, 0, -1);
        //            rb.velocity = moveDirection * moveSpeed;
        //        }
        //        else
        //        {
        //            Debug.Log("Kaka");
        //            rb.velocity = Vector3.zero;
        //        }
        //    }
        //}
        //if (horizontalInput == 0 && verticalInput == 0)
        //{
        //    if (rightCanMove)
        //    {
        //        moveDirection = new Vector3(1, 0, 0);
        //        rb.velocity = moveDirection * moveSpeed;
        //    }
        //    else
        //    {
        //        rb.velocity = Vector3.zero;
        //    }
        //}
        ////if (Input.GetKeyDown(KeyCode.DownArrow))
        ////{
        ////    while (downCanMove)
        ////    {
        ////        //transform.position += moveDirection;
        ////        Debug.Log("huhuhaha");
        ////    }
        ////}    
        #endregion
        if(getInput)
        {
            GetDirection();
            Move();
        }    
        
    }
    private void GetDirection()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isMoving)
        {
            isMoving = true;
            moveDirection = new Vector3(0, 0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !isMoving)
        {
            isMoving = true;
            moveDirection = new Vector3(0, 0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isMoving)
        {
            isMoving = true;
            moveDirection = new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !isMoving)
        {
            isMoving = true;
            moveDirection = new Vector3(1, 0, 0);
        }
    }
    private void Move()
    {
        if(isMoving)
        {
            
            if (moveDirection == new Vector3(0, 0, 1))
            {
                skin.transform.localEulerAngles = new Vector3(0, 0, 0);
                upCanMove = UpCheck();
                if(!upCanMove)
                {
                    isMoving = false;
                    moveDirection = Vector3.zero;
                }        
            }
            else if (moveDirection == new Vector3(0, 0, -1))
            {
                skin.transform.localEulerAngles = new Vector3(0, 180, 0);
                downCanMove = DownCheck();
                if (!downCanMove)
                {
                    isMoving = false;
                    moveDirection = Vector3.zero;
                }
            }
            else if (moveDirection == new Vector3(-1, 0, 0))
            {
                skin.transform.localEulerAngles = new Vector3(0, -90, 0);
                leftCanMove = LeftCheck();
                if (!leftCanMove)
                {
                    isMoving = false;
                    moveDirection = Vector3.zero;
                }
            }
            else if (moveDirection == new Vector3(1, 0, 0))
            {
                skin.transform.localEulerAngles = new Vector3(0, 90, 0);
                rightCanMove = RightCheck();
                if (!rightCanMove)
                {
                    isMoving = false;
                    moveDirection = Vector3.zero;
                }
            }
            anim.SetTrigger("Run");
            rb.velocity = moveDirection * moveSpeed;
        }
        else
        {
            anim.SetTrigger("Idle");
            rb.velocity = Vector3.zero;
        }
    }
    private bool UpCheck()
    {
        //Debug.DrawLine(new Vector3(neck.transform.position.x, neck.transform.position.y, neck.transform.position.z + 1), new Vector3(neck.transform.position.x, neck.transform.position.y, neck.transform.position.z + 1) + Vector3.down * 1.1f, Color.red);
        if (Physics.Raycast(new Vector3(neck.transform.position.x, neck.transform.position.y, neck.transform.position.z + 1), Vector3.down, out RaycastHit hit, raycastLength, groundLayer))
        {
            return true;
        }
        return false;
    }
    private bool DownCheck()
    {
        //Debug.DrawLine((new Vector3(neck.transform.position.x, neck.transform.position.y, neck.transform.position.z - 1)), new Vector3(neck.transform.position.x, neck.transform.position.y, neck.transform.position.z - 1) + Vector3.down * 1.1f, Color.red);
        if (Physics.Raycast(new Vector3(neck.transform.position.x, neck.transform.position.y, neck.transform.position.z - 1), Vector3.down, raycastLength, groundLayer))
        {
            return true;
        }
        return false;
    }
    private bool LeftCheck()
    {
        //Debug.DrawLine(new Vector3(neck.transform.position.x - 1, neck.transform.position.y, neck.transform.position.z), new Vector3(neck.transform.position.x - 1, neck.transform.position.y, neck.transform.position.z) + Vector3.down * 1.1f, Color.red);
        if (Physics.Raycast(new Vector3(neck.transform.position.x - 1, neck.transform.position.y, neck.transform.position.z), Vector3.down, raycastLength, groundLayer))
        {
            return true;
        }
        return false;
    }
    private bool RightCheck()
    {
        //Debug.DrawLine(new Vector3(neck.transform.position.x + 1, neck.transform.position.y, neck.transform.position.z), new Vector3(neck.transform.position.x + 1, neck.transform.position.y, neck.transform.position.z) + Vector3.down * 1.1f, Color.red);
        if (Physics.Raycast(new Vector3(neck.transform.position.x + 1, neck.transform.position.y, neck.transform.position.z), Vector3.down, raycastLength, groundLayer))
        {
            return true;
        }
        return false;
    }
}
