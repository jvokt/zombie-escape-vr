using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthText : MonoBehaviour {
	GameObject player;
	PlayerHealth health;
	private Text text;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		health = player.GetComponent <PlayerHealth> ();
	}

	void Awake() {
		text = GetComponent<Text>();
	}

	void LateUpdate() {
		text.text = "Health: " + (int) health.getHealth() + " / 100";
	}
}
