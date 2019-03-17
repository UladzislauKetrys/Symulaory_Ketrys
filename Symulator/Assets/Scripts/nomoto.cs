using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nomoto : MonoBehaviour {

    public Rigidbody Ship;
    public Slider velocity;
    public Slider course;
    private Vector3 euler;

    const float recoveryRate = 1000f;
    float verticalInput = 0.0f;
    float horizontalInput = 0.0f;
    const float T = 48.5f;
    const float K = 0.1232f;

	// Use this for initialization
	void Start () {
        Ship = GetComponent<Rigidbody>();

        velocity.onValueChanged.AddListener(Movement);
        course.onValueChanged.AddListener(Steer);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        verticalInput = Mathf.MoveTowards(verticalInput, (velocity.value), recoveryRate * Time.deltaTime);
        horizontalInput = Mathf.MoveTowards(horizontalInput, (course.value), recoveryRate * Time.deltaTime );
        Movement(velocity.value);
        Steer(course.value);
        
	}
    void Movement(float maxStrength)
    {
        Vector3 movement = new Vector3(0.0f, 0.0f, verticalInput);
        Ship.AddRelativeForce(movement);
    }

    void Steer(float maxStrength)
    {
        float r = (K * verticalInput * Time.deltaTime - horizontalInput * (Time.deltaTime - T)) / T;
        Ship.transform.rotation = Quaternion.Euler(0.0f, r * 180f * Time.deltaTime, 0.0f);
    }
}
