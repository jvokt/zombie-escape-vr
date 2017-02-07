using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {
	public GameObject enemy;
	public GameObject playerPos;

	private float timeDelay = 1;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Create", timeDelay, timeDelay);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Create () {
		Vector3 newPos = playerPos.transform.position;
		newPos.z += 20;
		//		newPos.z += 10 + 2 * Random.value - 1;
		newPos.x += 10 * (2 * Random.value - 1);
		//		newPos.y += 10 * Random.value;
		newPos.y = -1;
		Instantiate (enemy, newPos, Quaternion.Euler(0,180,0));
	}
}
