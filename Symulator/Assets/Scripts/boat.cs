using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boat : MonoBehaviour {

    public float turnSpeed = 1000f;
    public float accelerateSpeed = 1000f;
 

    private Rigidbody rgbd;

	// Use this for initialization
	void Start () {

        rgbd = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rgbd.AddTorque(0f, h * turnSpeed * Time.deltaTime, 0f);
        rgbd.AddForce(transform.forward * v * accelerateSpeed * Time.deltaTime);

      
		
	}
}
