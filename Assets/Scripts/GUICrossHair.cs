using UnityEngine;
using System.Collections;

public class GUICrossHair : MonoBehaviour {
	public Texture2D crossHairTex;
	Vector2 windowSize;
	Rect crossHairRect;

	// Use this for initialization
	void Start () {
		crossHairTex = new Texture2D (2, 2);
		windowSize = new Vector2 (Screen.width, Screen.height);
		CalculateRect ();
	}
	
	// Update is called once per frame
	void Update () {
		if (windowSize.x != Screen.width || windowSize.y != Screen.height) {
			CalculateRect ();
		}
	}

	void CalculateRect()
	{
		float w = (windowSize.x - crossHairTex.width) / 2f;
		float h = (windowSize.y - crossHairTex.height) / 2f;
		crossHairRect = new Rect (w, h, crossHairTex.width, crossHairTex.height);
	}

	void onGUI()
	{
		GUI.DrawTexture (crossHairRect, crossHairTex);
	}
}
