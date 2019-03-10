using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour {

    public GameObject settings; 

    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    public void Settings()
    {
        settings.SetActive(!settings.activeSelf);
    }


    public void Exit()
    {
        Application.Quit();
    }

    public void setSound(float value)

    {
        Global.sounde = value;
    }
}
