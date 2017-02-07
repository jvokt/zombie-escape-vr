using UnityEngine;
using System.Collections;

public class Gun_Flare : MonoBehaviour {

    public ParticleSystem gunFlare;
    public Light light;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            gunFlare.Stop();
            gunFlare.Play();
            light.enabled = true;
        }

    }
}
