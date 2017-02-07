using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
	public Cardboard cb;
	public bool paused;
	// Use this for initialization
	void Start () {
		transform.position = cb.transform.position;
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!paused) {
			Vector3 nextPos = cb.transform.position;
			nextPos.z += 0.02f;
			if (nextPos.z > 80) {
				GameObject[] zombies = GameObject.FindGameObjectsWithTag ("Enemy");
				foreach (GameObject g in zombies) {
					Vector3 zPos = g.transform.position;
					zPos.z -= 80f;
					g.transform.position = zPos;
				}
			}
			nextPos.z = nextPos.z % 80;
			cb.transform.position = nextPos;
			transform.position = nextPos;
		}
	}

	public void PauseOrPlayGame()
	{
		if (paused)
			Play ();
		else
			Pause ();
	}

	public void Pause()
	{
		Time.timeScale = 0f;
		paused = true;
	}

	public void Play()
	{
		Time.timeScale = 1f;
		paused = false;
	}

	public void ToggleVRMode() {
		Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
	}

	public void RestartGame()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		Play ();
	}
}
