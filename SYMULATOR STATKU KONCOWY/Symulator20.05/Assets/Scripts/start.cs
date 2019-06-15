using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour {

    public GameObject settings;
    public Slider slider;
    public Text valueCount;



    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    public void Map()
    {
        Application.LoadLevel(2);
    }

    public void Settings()
    {
        settings.SetActive(!settings.activeSelf);
    }
    void Update()
    {

        {
            valueCount.text = slider.value.ToString("0");     //wyprowodzanie informacji o głosnosci na slajderu
            AudioListener.volume = slider.value;
        }
    }
}
