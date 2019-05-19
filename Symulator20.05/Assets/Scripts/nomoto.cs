using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI;

public class nomoto : MonoBehaviour
{

    private float speed;
    private float turn;
    public Rigidbody Ship;

    public Slider speedS;
    public Slider turnS;

    public Text speedI;
    public Text rudderA;
    public Text speedP;
    public Text turnP;
    public Text cogV;

    public float kn;
    public float y = 0.0f;
    public float x = 0.0f;
    public float z = 0.0f;
    public float ROT = 0.0f;
    public float COG = 0.0f;
    float K = 0.07f;

    public float sigmaR = 0.0f;
    public float maxSpeed = 10.29f;
    public float actualSpeed = 0.0f;
    public float COGv2;
    Vector3 cachedPosition;

    public void speedSlider(float value)
    {
        speed = value;

    }
    public void turnSlider(float value)
    {
        turn = value;
    }
    public void resetSpeed()
    {
        speedS.value = 0;
    }
    public void resetTurn()
    {
        turnS.value = 0;
    }

    public void set50()
    {
        speedS.value = 50;
    }

    public void setm50()
    {
        speedS.value = -50;
    }
    public void set100()
    {
        speedS.value = 100;
    }
    public void setm100()
    {
        speedS.value = -100;
    }

    void Start()
    {
        Ship = GetComponent<Rigidbody>();

        speedS = GetComponent<Slider>();
        turnS = GetComponent<Slider>();

    }
    void Update()
    {
        
        sigmaR = Mathf.MoveTowards(sigmaR, turn, 2.96f * Time.deltaTime);
        actualSpeed = Mathf.MoveTowards(actualSpeed, speed / 100 * maxSpeed, 0.15f * Time.deltaTime);
        if (actualSpeed != 0)
        {
            ROT += (K * (sigmaR) - ROT) * Time.deltaTime;
            COG += ROT * Time.deltaTime;
            x += actualSpeed * Time.deltaTime * Mathf.Sin(COG * Mathf.PI / 180);
            z += actualSpeed * Time.deltaTime * Mathf.Cos(COG * Mathf.PI / 180);
            transform.position = new Vector3(x, y, z);
            transform.rotation = Quaternion.Euler(0, COG, 0);

            kn = (actualSpeed) * 1.9438f; 
            speedI.text = kn.ToString("0.0");
            rudderA.text = sigmaR.ToString("0");
            speedP.text = speed.ToString("0");
            turnP.text = turn.ToString("0");
            COGv2 = COG % 360;
            cogV.text = COGv2.ToString("0.00");
        }
    }
}