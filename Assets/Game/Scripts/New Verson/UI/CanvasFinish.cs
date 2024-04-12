using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFinish : UICanvas
{
    public void QuitButton()
    {
        DatingManager.Instance.ResetData();
        Application.Quit();
    }

}
