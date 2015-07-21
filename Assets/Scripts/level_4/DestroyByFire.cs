using UnityEngine;
using System.Collections;

public class DestroyByFire : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController4 gameController;
	
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent <GameController4>();
		}
		if (gameControllerObject == null) 
		{
			Debug.Log("Cannot Find GameController Script");
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Boundary")
		{
			return;
		}
		if (other.tag == "Player") 
		{
			Instantiate(playerExplosion, transform.position, transform.rotation);
			Handheld.Vibrate();
			gameController.GameOver ();
			Destroy (other.gameObject);
			Destroy (gameObject);
			gameController.Update ();
		}
		Instantiate(explosion, transform.position, transform.rotation);
		gameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
