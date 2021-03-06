﻿using UnityEngine;
using System.Collections;

public class DestroyByContact2 : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController2 gameController;
	
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent <GameController2>();
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
