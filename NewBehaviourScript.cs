using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public GameObject boat;
    public GameObject boatCamera;
    public GameObject player;
    public GameObject playerStart;
    public GameObject shipCam;
    public GameObject ship;

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("1"))
        {
            boat.GetComponent<Rigidbody>().isKinematic = false;
            boat.GetComponent<boat>().enabled = true;
            boatCamera.SetActive(true);

            player.SetActive(false);
            
        }

        if (Input.GetKey("2"))
        {
            boat.GetComponent<Rigidbody>().isKinematic = true;
            boat.GetComponent<boat>().enabled = false;
            boatCamera.SetActive(false);

            player.SetActive(true);
            player.transform.position = playerStart.transform.position;
        }

        if (Input.GetKey("3"))
        {
            boat.GetComponent<Rigidbody>().isKinematic = false;
            boat.GetComponent<boat>().enabled = true;
            boatCamera.SetActive(false);

            player.SetActive(false);

            ship.GetComponent<Rigidbody>().isKinematic = false;
            ship.GetComponent<boat>().enabled = true;
            shipCam.SetActive(true);
        }
	}
}
