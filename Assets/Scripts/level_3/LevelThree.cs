using UnityEngine;
using System.Collections;

public class LevelThree : MonoBehaviour {

	public Texture btnTexture;
	private float h;
	private float w;
	private float pos;
	public int t;
	public GUIText scoreText;
	void Awake()
	{
		t = PlayerPrefs.GetInt ("TempScore");
		h = Screen.height/10;
		w = Screen.width;
		pos = Screen.height/2;
		scoreText.text = "Score : " + t;
	}
	void OnGUI() {
		if (!btnTexture) {
			Debug.LogError("Please assign a texture on the inspector");
			return;
		}
		if (GUI.Button (new Rect (0, pos, w, h), "Start")) {
			Application.LoadLevel ("level_3");
		}
		
	}
	void Update () 
	{
		if (Application.platform == RuntimePlatform.Android) {
			
			if (Input.GetKey (KeyCode.Escape)) {
				
				Application.LoadLevel ("menu");
				
				// Insert Code Here (I.E. Load Scene, Etc)
				
				//Application.Quit();
				
				
				
				return;
				
			}
		}
		if (Application.platform == RuntimePlatform.WP8Player) {
			
			if (Input.GetKey (KeyCode.Escape)) {
				
				Application.LoadLevel ("menu");
				
				// Insert Code Here (I.E. Load Scene, Etc)
				
				//Application.Quit();
				
				
				
				return;
				
			}
		}
	}
}
