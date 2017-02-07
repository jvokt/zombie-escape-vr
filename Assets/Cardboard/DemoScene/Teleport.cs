// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Teleport : MonoBehaviour {
	private GameObject player;
  private Vector3 startingPosition;
	UnityEngine.AI.NavMeshAgent nav;
	PlayerHealth ph;

  void Start() {
    startingPosition = transform.localPosition;
    SetGazedAt(false);
	nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform.root.gameObject;
		ph = player.GetComponentInChildren<PlayerHealth> ();
  }
		
  public void SetGazedAt(bool gazedAt) {
    GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
  }

  public void Reset() {
    transform.localPosition = startingPosition;
  }

  public void ToggleVRMode() {
    Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
  }

	public void TeleportRandomly() {
		//    Vector3 direction = Random.onUnitSphere;
		//    direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
		//    float distance = 2 * Random.value + 1.5f;
		//    transform.localPosition = direction * distance;
		Vector3 newPos = player.transform.position;
		newPos.z += 20;
		//		newPos.z += 10 + 2 * Random.value - 1;
		newPos.x += 10 * (2 * Random.value - 1);
		//		newPos.y += 10 * Random.value;
		newPos.y = .5f;
		transform.localPosition = newPos;
	}

	public void GotHit() {
		transform.root.gameObject.SetActive (false);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
//			health -= damageAmount;
			//			tel.TeleportRandomly ();
//			tel.GotHit ();
			ph.gotDamaged();
			GotHit();
		}
	}

	void Update ()
	{
		nav.SetDestination (player.transform.position);
		transform.root.position = transform.position;
		transform.root.rotation = transform.rotation;
	}

}