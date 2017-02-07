using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKey(KeyCode.Mouse0))
        {
            Instantiate(bullet, transform.position, transform.rotation);

            GetComponent<AudioSource>().Play();
            

        }

	}
}
