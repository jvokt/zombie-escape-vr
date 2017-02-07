using UnityEngine;
using System.Collections;

public class PlaneGeneration : MonoBehaviour {

	public GameObject newPlane;
	public GameObject newPlanePosition;
	//public GameObject newHouse;


	void OnTriggerEnter(Collider other){
		Vector3 planePosition = new Vector3 ();
		Quaternion planeRotation = new Quaternion ();
		//		Quaternion houseRotation = new Quaternion ();
		planePosition = newPlanePosition.transform.position;
		//planePosition.z += 10;
		planeRotation = newPlanePosition.transform.rotation;
		//houseRotation = newHouse.transform.rotation;
		Instantiate (newPlane, planePosition, planeRotation);
		//Instantiate (newHouse, planePosition, houseRotation);
	}
}
