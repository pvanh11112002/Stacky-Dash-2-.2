using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : Singleton<FXManager>
{
    public FX[] FX;
    public void Play(string name, Transform transform)
    {
        for (int i = 0; i < FX.Length; i++)
        {
            if (FX[i].name == name)
            {
                Instantiate(FX[i].FXPrefabs, transform.position, transform.rotation);
            }    
        }
    }
    public void Play(string name, Vector3 pos)
    {
        for (int i = 0; i < FX.Length; i++)
        {
            if (FX[i].name == name)
            {
                Instantiate(FX[i].FXPrefabs, pos, Quaternion.identity);
            }
        }
    }

}
