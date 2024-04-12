using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountPoint : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] TextMeshProUGUI currentPointText;
    private void OnEnable()
    {
        currentPointText.text = DatingManager.Instance.userData.Point.ToString();
    }
    void Update()
    {
        pointText.text = PlayerControl.Instance.pointOfPlayer.ToString();    
    }   
}
