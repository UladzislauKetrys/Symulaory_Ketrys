using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainview : MonoBehaviour {

    public GameObject ship;
    public float speedCam;
    public float speedScroll;
    public float minDist;
    public float maxDist;

    private bool _isActive = false;
    private float _distance;
    private float _x;
    private float _y;

    void LateUpdate()
    {
        _x = Input.GetAxis("Mouse X") * speedCam * 10;
        _y = Input.GetAxis("Mouse Y") * -speedCam * 10;

        if (Input.GetMouseButtonDown(1))
        {
            _isActive = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            _isActive = false;
        }

        if (_isActive)
        {
            transform.RotateAround(ship.transform.position, transform.up, _x * Time.deltaTime);
            transform.RotateAround(ship.transform.position, transform.right, _y * Time.deltaTime);

            transform.rotation = Quaternion.LookRotation(ship.transform.position - transform.position);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }

       

    }

}
