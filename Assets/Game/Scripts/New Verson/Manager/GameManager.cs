using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

// Dùng Game Manager để lưu trữ các giá trị có thể chọc đến từ mọi nơi trong project, MỌI NƠI.
// Đặt nó trong Main Scene, vì nó chỉ dùng để quản lý luồng game, mà mõi game thì một scene, nên ta có thể làm như vậy
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool lose = false;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }
    private void Update()
    {
        if(lose)
        {
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<CanvasDefeat>();
            Time.timeScale = 0;
            lose = false;
        }    
    }

}
