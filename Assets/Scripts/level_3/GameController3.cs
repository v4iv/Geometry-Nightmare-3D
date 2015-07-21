using UnityEngine;
using System.Collections;

public class GameController3 : MonoBehaviour 
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
	private int temp;
	private int go;
	
	void Awake(){
		temp = PlayerPrefs.GetInt ("TempScore");
		go = PlayerPrefs.GetInt ("TempScore");
		PlayerPrefs.SetInt ("continue", 5);
	}
	
	
	void Start()
	{
		gameOver = false;
		//restart = false;
		restartText.text = "";
		gameOverText.text = "";
		
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
				Application.LoadLevel ("6asq43pi");
			}
			if(Application.platform == RuntimePlatform.Android)
			{
				if(Input.GetKey (KeyCode.Escape))
				{
					Application.LoadLevel ("menu");
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
			waveText.text = "WAVE " + wave;
			if(wave > 5 && gameOver == false)
			{
				Application.LoadLevel ("2piRH");
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
		scoreText.text = "Score : " + score;
		temp += score;
		PlayerPrefs.SetInt ("TempScore", temp);
		if (temp > PlayerPrefs.GetInt ("HighScore")) {
			PlayerPrefs.SetInt("HighScore",temp);		
		}
	}
	public void GameOver()
	{
		gameOverText.text = "Game Over";
		restartText.text = "Tap to Restart";
		gameOver = true;
		PlayerPrefs.SetInt ("TempScore",go);
	}
}
