using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplePoints : MonoBehaviour
{
    [SerializeField] float times;
    private void OnCollisionEnter(Collision collision)
    {
        PlayerControl.Instance.timesToMultiple = times;
    }
}
