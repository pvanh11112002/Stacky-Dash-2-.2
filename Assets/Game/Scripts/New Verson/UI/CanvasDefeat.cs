using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasDefeat : UICanvas
{
    private void OnEnable()
    {
        AudioManager.Instance.Play("Lose");
    }
    public void RetryButton()
    {
        AudioManager.Instance.Play("Click");
        Debug.Log("DatingManager.Instance.userData.lvTOLoad: " + DatingManager.Instance.userData.lvToLoad);
        SceneManager.UnloadSceneAsync(DatingManager.Instance.userData.lvToLoad + 1);
        Close(0);
        PlayerControl.Instance.OnDestroy();
        Time.timeScale = 1.0f;
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }   
    public void QuitButton()
    {
        Application.Quit();
    }    
}
