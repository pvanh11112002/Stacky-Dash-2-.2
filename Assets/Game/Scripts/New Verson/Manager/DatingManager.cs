using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;

public class UserData
{
    public int defaultCurrentLevel = 1;             // Default Level
    public float defaultPoint = 100;                // Default Point
    public float currentPoint = 0;
    public float earnedPoint = 0;                 // Điểm kiếm được
    public int lvToLoad = 1;                    // Lv tiếp tao
    public float Point = 100;                       // Điểm tổng  = ĐIểm hiện tại + ĐIểm kiếm được
}
public class DatingManager : Singleton<DatingManager>
{
    
    public UserData userData;
    
    private void Start()
    {
        //SaveUserData();
        LoadUserData();        
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log($"Dữ liệu người dùng: {JsonUtility.ToJson(userData)}");
        } 
        else if(Input.GetKeyUp(KeyCode.R))
        {
            ResetData();
        }    
    }
    private void LoadUserData()
    {
        // Lấy ra chuỗi json với khóa là "USER_DATA"
        string json = PlayerPrefs.GetString("USER_DATA");
        if(string.IsNullOrEmpty(json))
        {
            userData = new UserData();
        }    
        else
        {
            userData = JsonUtility.FromJson<UserData>(json);
        }
    }
    public void SaveUserData()
    {
        // Dùng để lưu trữ dữ liệu
        string json = JsonUtility.ToJson(userData);             // Chuyển đổi đối tượng userData thành chuỗi json
        PlayerPrefs.SetString("USER_DATA", json);               // Lưu
        PlayerPrefs.Save();
    }
    public void SaveCurrentPoint(float point)
    {
        userData.currentPoint = point;
        SaveUserData();
    }
    public void SaveEarnedPoint(float point)
    {
        userData.earnedPoint = point;
        SaveUserData();
    }    
    public void AddPoint(float point)
    {
        userData.Point += point;
        SaveUserData();
    }    
    public void SaveLevel(int currentLevel)
    {
        userData.lvToLoad = currentLevel;
        SaveUserData();
    }
    public void ResetData()
    {
        userData.lvToLoad = userData.defaultCurrentLevel;
        userData.currentPoint = 0;
        userData.earnedPoint = 0;
        userData.Point = userData.defaultPoint;
        SaveUserData();
    }
}

