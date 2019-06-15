using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class echo : MonoBehaviour {

    public GameObject echosonda;
    public Text distanceI;

	void Start () {
		
	}

	void Update () {
        System.Random rand = new System.Random();
        double u1 = 1.0 - rand.NextDouble();
        double u2 = 1.0 - rand.NextDouble();
        double blad = ((System.Math.Sqrt(-2.0 * System.Math.Log(u1)) * System.Math.Sin(2.0 * System.Math.PI * u2)) * 0.3);   //bląd pomiarowy

        RaycastHit collide;
        Ray kierunek = new Ray(transform.position, Vector3.down );    //raycasting
        Debug.DrawRay(transform.position, Vector3.down * 100000);

        if (Physics.Raycast(kierunek, out collide))
        {
            if (collide.collider.tag == "Terrain")
            {
                double distance = collide.distance + blad;
                distanceI.text = distance.ToString("0.0");
            }
        }
	}
}
