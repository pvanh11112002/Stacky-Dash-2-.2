using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SpashScreen : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] float time = 5;
   
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SceneManager.sceneCountInBuildSettings);
        image.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(image.fillAmount == 1)
        {
            SceneManager.LoadScene("Main Scene");
        }    
        image.fillAmount += Time.deltaTime * 1 / time;
    }
}
