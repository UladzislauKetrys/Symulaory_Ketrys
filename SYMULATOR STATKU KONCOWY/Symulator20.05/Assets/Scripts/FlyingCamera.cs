using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCamera : MonoBehaviour {

    public float mouseSensitivity = 3f;
    public float speed = 5f;
    private Vector3 transfer;
    public float minimumX = -360f;
    public float maximumX = 360f;
    public float minimumY = -60f;
    public float maximumY = 60f;
    float rotationX = 0f;
    float rotationY = 0f;
    Quaternion originalRotation;

    void Start()
    {

                originalRotation = transform.rotation;
        }
        
        void Update()
        {

                rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;               //załozamy podstawy ruchu myszą
                rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity; 
                rotationX = ClampAngle (rotationX, minimumX, maximumX);
                rotationY = ClampAngle (rotationY, minimumY, maximumY);
                Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
                Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, Vector3.left);
                transform.rotation = originalRotation * xQuaternion * yQuaternion;

                if (Input.GetKeyDown(KeyCode.LeftShift))                              //klawisze dla pomocy ruchu kamery
                        speed *= 10;

                else if (Input.GetKeyUp(KeyCode.LeftShift))
                        speed /= 10;
                Vector3 newPos = new Vector3(0, 1, 0);

                if (Input.GetKey(KeyCode.E))
                    transform.position += newPos * speed * Time.deltaTime;

                else if (Input.GetKey(KeyCode.Q))
                    transform.position -= newPos * speed * Time.deltaTime;


                transfer = transform.forward * Input.GetAxis("Vertical");
                transfer += transform.right * Input.GetAxis("Horizontal");
                transform.position += transfer * speed * Time.deltaTime;
        }

        public static float ClampAngle(float angle, float min, float max)     //ustawienie prawidlowego kąta wizji kamery
        {
            if (angle < -360F) angle += 360F;
            if (angle > 360F) angle -= 360F;
            return Mathf.Clamp(angle, min, max);
        }
    

        public void Back()
        {
            Application.LoadLevel(0);
        }
        
}
