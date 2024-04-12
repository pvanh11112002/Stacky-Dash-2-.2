using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningPoint : MonoBehaviour
{
    [SerializeField] Transform popupPos;
    private void OnCollisionEnter(Collision collision)
    {
        // Win
        
        Debug.Log(PlayerControl.Instance.pointOfPlayer);
        Debug.Log(PlayerControl.Instance.timesToMultiple); 
        PlayerControl.Instance.pointOfPlayer *= PlayerControl.Instance.timesToMultiple;
        DatingManager.Instance.SaveEarnedPoint(PlayerControl.Instance.pointOfPlayer);
        Debug.LogWarning("YOU ARE WIN WITH " + PlayerControl.Instance.pointOfPlayer + " POINTS");
        FXManager.Instance.Play("Win1", popupPos);
        //LogicalOfMainScene.Instance.lvToLoad++;
        DatingManager.Instance.userData.lvToLoad++;
        DatingManager.Instance.SaveCurrentPoint(DatingManager.Instance.userData.Point);
        DatingManager.Instance.AddPoint(PlayerControl.Instance.pointOfPlayer);
        DatingManager.Instance.SaveLevel(DatingManager.Instance.userData.lvToLoad);
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<CanvasVictory>();
        PlayerControl.Instance.OnDestroy();
    }
    
}
