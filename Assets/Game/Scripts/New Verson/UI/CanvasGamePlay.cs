using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CanvasGamePlay : UICanvas
{
    public bool soundOn = true;
    public void RetryButton()
    {
        AudioManager.Instance.Play("Click");
        Debug.Log("Đã ấn nút retry button ở trong canvas gameplay");
        Debug.Log("DatingManager.Instance.userData.lvTOLoad: " + DatingManager.Instance.userData.lvToLoad);
        SceneManager.UnloadSceneAsync(DatingManager.Instance.userData.lvToLoad + 1);
        Close(0);
        PlayerControl.Instance.OnDestroy();
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }    
    public void TurnoffSound()
    {
        foreach(var s in AudioManager.Instance.sounds)
        {
            if(soundOn)
            {
                s.source.volume = 0;
                soundOn = false;
            }    
            else if(!soundOn)
            {
                   
                s.source.volume = 1;
                if (s.name == "Soundtrack")
                {
                    Debug.Log("soundtrack = 0.02");
                    s.source.volume = 0.02f;
                }
                soundOn = true;
            }    
        }    
    }
    public void Quit()
    {
        Application.Quit();
    }
}
