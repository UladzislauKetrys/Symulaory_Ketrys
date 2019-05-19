using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour {

    public GameObject settings;
    public Slider slider;
    public Text valueCount;

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



    void Update()
    {

        {
            valueCount.text = slider.value.ToString();
            AudioListener.volume = slider.value;
        }
    }

}
