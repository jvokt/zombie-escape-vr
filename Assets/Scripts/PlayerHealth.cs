using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
     Texture tex1,tex2,tex3,tex4; 
	//public Image damage;
	double startingHealth = 100;
	double health;
	double damageAmount = 10;
	double healingAmount = .01;
	GameObject enemy;
//	Teleport tel;

	// Use this for initialization
	void Start () {
		health = startingHealth;
//		enemy = GameObject.FindGameObjectWithTag ("Enemy");
//		tel = enemy.GetComponentInChildren <Teleport> ();
        tex1 = Resources.Load("tex1") as Texture;
        tex2 = Resources.Load("tex2") as Texture;
        tex3 = Resources.Load("tex3") as Texture;
        tex4 = Resources.Load("tex4") as Texture;
	}

	public double getHealth()
	{
		return health;
	}

	public void gotDamaged()
	{
		health -= damageAmount;
	}

	// Update is called once per frame
	void Update () {
		if (health <= 0)
			GameOver ();
		else if (health < 100 && health > 0)
			health += healingAmount;
		if (health > 100)
			health = 100;
		// health = 0 -> alpha = .5
		// health = 100 -> alpha = 0
		//float alpha = (.5f)*(float)(1 - health / 100);
		//damage.color = new Color (1f, 0f, 0f, alpha);
	}

	void GameOver ()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("PlayerObject");
		PlayerMovement pm = player.GetComponent <PlayerMovement>();
		pm.Pause ();
	}

	// when health goes to zero, pause, disable play, show game over would you like to play again?, then restart scene
//
//	void OnTriggerEnter(Collider other){
//		if (other.gameObject.CompareTag ("Enemy")) {
//			health -= damageAmount;
////			tel.TeleportRandomly ();
//			tel.GotHit ();
//		}
//	}

    void OnGUI()
    {
        
        if (health < 90)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex1);
        }
        if (health <= 80)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex2);
        }
        if (health <= 60)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex3);
        }
        if (health <= 40)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex4);
        }
    }
}
