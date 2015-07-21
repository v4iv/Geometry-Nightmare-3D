using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	private int score;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText waveText;
	public int wave = 1;


	//private bool restart;
	private bool gameOver;

	void Awake (){
		PlayerPrefs.SetInt ("continue", 1);
	}

	void Start()
	{
		gameOver = false;
		//restart = false;
		restartText.text = "";
		gameOverText.text = "";
		scoreText.fontSize = 18;
		waveText.fontSize = 20;
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	public void Update()
	{
		if (gameOver) 
		{
			//if (Input.GetKeyDown (KeyCode.R))
			//{
			//	Application.LoadLevel (Application.loadedLevel);
			//}
			if (Input.GetTouch (0).phase == TouchPhase.Began) 
			{
				Application.LoadLevel ("6ASQ");
			}
			if (Application.platform == RuntimePlatform.Android)
			{
				if(Input.GetKey (KeyCode.Escape))
				{
					Application.LoadLevel("menu");
				}
			}
		}
		if (Application.platform == RuntimePlatform.Android) {
			
			if (Input.GetKey (KeyCode.Escape)) {
				
				Application.LoadLevel ("menu");
				
				// Insert Code Here (I.E. Load Scene, Etc)
				
				// OR Application.Quit();
				
				
				
				return;
				
			}
		}
		if (Application.platform == RuntimePlatform.WP8Player) {
			
			if (Input.GetKey (KeyCode.Escape)) {
				
				Application.LoadLevel ("menu");
				
				// Insert Code Here (I.E. Load Scene, Etc)
				
				// OR Application.Quit();
				
				
				
				return;
				
			}
		}
	}
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while(true)
		{
			for (int i = 0; i < hazardCount ; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);

			}
			yield return new WaitForSeconds (waveWait);
			hazardCount = hazardCount + 10;
			wave++;
			waveText.fontSize = 20;
			waveText.text = "WAVE " + wave;
			if(wave > 5 && gameOver == false)
			{
				Application.LoadLevel ("43pi");
			}
			if(gameOver)
			{

				//restart = true;
				break;
			}
		}
	}
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	void UpdateScore()
	{
		scoreText.fontSize = 18;
		scoreText.text = "Score : " + score;
		PlayerPrefs.SetInt ("TempScore", score);
		if (score > PlayerPrefs.GetInt ("HighScore")) {
			PlayerPrefs.SetInt("HighScore",score);		
		}


	}
	public void GameOver()
	{
		gameOverText.fontSize = 25;
		gameOverText.text = "Game Over";
		restartText.fontSize = 20;
		restartText.text = "Tap to Restart";
		gameOver = true;
		PlayerPrefs.DeleteKey ("TempScore");
	}
}
