using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour {

    public Camera cam1;
    public Camera cam2;
    public Camera cam3;


    public void switchcam(int x)
    {
        off();

        if (x == 1)
        {
            cam1.enabled = true;
        }
        else if (x == 2)
        {
            cam2.enabled = true;
        }
        else
        {
            cam3.enabled = true;
        }
    }

        public void off()
        {
            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = false;
        }
    }
