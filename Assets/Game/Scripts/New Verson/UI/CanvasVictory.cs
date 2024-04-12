using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasVictory : UICanvas
{
    [SerializeField] TextMeshProUGUI currentPoints;
    [SerializeField] TextMeshProUGUI earnedPoints;
    [SerializeField] TextMeshProUGUI newPoints;
    [SerializeField] TextMeshProUGUI nextLevel;


    private void OnEnable()
    {
        AudioManager.Instance.Play("Win");
        currentPoints.text = $"Current Point: {DatingManager.Instance.userData.currentPoint}";
        earnedPoints.text = $"Earned Point: {DatingManager.Instance.userData.earnedPoint}";
        newPoints.text = DatingManager.Instance.userData.Point.ToString();
        if(DatingManager.Instance.userData.lvToLoad <= 3) //3 ở đây là số lv tối đa
        {
            nextLevel.text = $"Level To Load: {DatingManager.Instance.userData.lvToLoad}";
        }
        else
        {
            nextLevel.text = "Null";
        }


    }
    public void VictoryButton()
    {
        AudioManager.Instance.Play("Click");
        Debug.Log("MCK + " + DatingManager.Instance.userData.lvToLoad);
        SceneManager.UnloadSceneAsync(DatingManager.Instance.userData.lvToLoad);
        UIManager.Instance.OpenUI<CanvasMainMenu>();
        Close(0);
    }
}
