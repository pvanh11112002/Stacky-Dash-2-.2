using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public Transform[] targetPoints;
    [SerializeField] Transform headBridge;
    public int numberOfPoint = 0;
    private void Start()
    {    
        for(int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            if (this.gameObject.gameObject.transform.GetChild(i).gameObject.tag == "Drop")
            {
                numberOfPoint++;
            }
        }
        targetPoints = new Transform[numberOfPoint];
        for (int i = 0; i < numberOfPoint; i++)
        {
            if(this.gameObject.gameObject.transform.GetChild(i).gameObject.tag == "Drop")
            {
                targetPoints[i] = this.gameObject.transform.GetChild(i).transform;
            }    
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<MovingOnBridge>().targetPoints = this.targetPoints;
            collision.gameObject.GetComponent<MovingOnBridge>().enabled = true;
            FXManager.Instance.Play("Win1", headBridge);
        }
    }
}
