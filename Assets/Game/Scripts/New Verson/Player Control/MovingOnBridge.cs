using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingOnBridge : MonoBehaviour
{
    public Transform[] targetPoints; // Các điểm cần di chuyển đến
    [SerializeField] float moveDuration; // Thời gian di chuyển
    [SerializeField] int currentTargetIndex = 0;
    
    private void OnEnable()
    {
        MovingControl2.Instance.getInput = false;
        MoveToNextPoint();
    }
    private void Update()
    {
        
    }
    private void OnDisable()
    {
        MovingControl2.Instance.getInput = true;
        MovingControl2.Instance.anim.SetTrigger("Idle");
    }
    private void MoveToNextPoint()
    {
        if (currentTargetIndex < targetPoints.Length)
        {
            MovingControl2.Instance.anim.SetTrigger("Run");
            transform.DOMove(targetPoints[currentTargetIndex].position, moveDuration).SetEase(Ease.OutQuad).OnComplete(() => MoveToNextPoint()); // Di chuyển xong, chuyển đến điểm tiếp theo
            currentTargetIndex++;
        }
        else 
        {
            currentTargetIndex = 0;
            this.targetPoints = null;
            this.enabled = false;
            
        }
    }
}
