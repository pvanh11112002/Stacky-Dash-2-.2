using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tEST : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển của nhân vật
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Kiểm tra xem người dùng đã nhấn nút vuốt (ví dụ: chuột trái) hay không
        if (Input.GetMouseButtonDown(0))
        {
            // Sử dụng AddForce để di chuyển nhân vật theo hướng mong muốn
            rb.AddForce(transform.forward * moveSpeed, ForceMode.VelocityChange);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Finish")
        {
            rb.velocity = Vector3.zero;
        }    
    }
}

