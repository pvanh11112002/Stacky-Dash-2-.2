using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasMainMenu : UICanvas
{
    [SerializeField] TextMeshProUGUI points;
    [SerializeField] GameObject playerPrefabs;
    [SerializeField] string url;
    [SerializeField] int maxLv;
    public GameObject[] levels;
    
    private void OnEnable()
    {
        if (DatingManager.Instance.userData.lvToLoad <= maxLv)
        {
            foreach (var level in levels)
            {
                level.gameObject.SetActive(false);
            }
            Debug.Log(DatingManager.Instance.userData.lvToLoad);
            SceneManager.LoadScene(DatingManager.Instance.userData.lvToLoad + 1, LoadSceneMode.Additive);           
            Instantiate(playerPrefabs, new Vector3(0, 0, 0), Quaternion.identity);
            FXManager.Instance.Play("Respawn", Vector3.zero);
            levels[DatingManager.Instance.userData.lvToLoad - 1].gameObject.SetActive(true);
            points.text = DatingManager.Instance.userData.Point.ToString();
        }
        
    }
    public void PlayButton()
    {
        if(DatingManager.Instance.userData.lvToLoad < SceneManager.sceneCountInBuildSettings - 1)
        {
            MovingControl2.Instance.getInput = true;
            Scene loadedScene = SceneManager.GetSceneByBuildIndex(DatingManager.Instance.userData.lvToLoad + 1);
            if (loadedScene.IsValid())
            {
                SceneManager.SetActiveScene(loadedScene);

            }
            else
            {
                Debug.LogError($"Không thể tìm thấy scene");
            }
        }    
        

        AudioManager.Instance.Play("Click");
        if (DatingManager.Instance.userData.lvToLoad <= maxLv)
        {
            MovingControl2.Instance.getInput = true;
            UIManager.Instance.OpenUI<CanvasGamePlay>();
            Close(0);
            
        }    
        else
        {
            Debug.LogWarning("Hết scene rồi");
            UIManager.Instance.OpenUI<CanvasFinish>();
            Close(0);
        }
    }
    public void OnClickAds()
    {
        Debug.Log("Mày đã ấn vào quảng cáo");
        Application.OpenURL(url);
    }    
}
