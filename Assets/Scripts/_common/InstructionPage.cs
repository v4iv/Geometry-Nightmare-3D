using UnityEngine;
using System.Collections;

public class InstructionPage : MonoBehaviour 
{

	public GUIText load;
	public Texture btnTexture;
	private float h;
	private float w;
	private float pos;
	public int t;
	public GUIText valueText;
	private int cl;
	void Awake()
	{
		h = Screen.height/10;
		w = Screen.width;
		pos = Screen.height/2;
		PlayerPrefs.DeleteKey ("TempScore");
		t = PlayerPrefs.GetInt ("HighScore");
		valueText.text = "0"+t;
		cl = PlayerPrefs.GetInt ("continue");
	}
	void OnGUI() {
		if (!btnTexture) {
			Debug.LogError("Please assign a texture on the inspector");
			return;
		}
		if (GUI.Button (new Rect (0, pos, w, h), "Play")) {
						Application.LoadLevel ("6ASQ");
			PlayerPrefs.DeleteKey("continue");
						load.text = "Loading . . .";
				}
		if (!btnTexture) {
			Debug.LogError("Please assign a texture on the inspector");
			return;
		}
		if (GUI.Button (new Rect (0, pos-h, w, h), "Continue")) {
			Application.LoadLevel (cl);
			load.text = "Loading . . .";
		}


	}
	void Update () 
	{
		if (Application.platform == RuntimePlatform.Android) {
			
			if (Input.GetKey (KeyCode.Escape)) {
				
				//Application.LoadLevel ("menu");
				
				// Insert Code Here (I.E. Load Scene, Etc)
				
				Application.Quit();
				
				
				
				return;
				
			}
		}
		if (Application.platform == RuntimePlatform.WP8Player) {
			
			if (Input.GetKey (KeyCode.Escape)) {
				
				//Application.LoadLevel ("menu");
				
				// Insert Code Here (I.E. Load Scene, Etc)
				
				Application.Quit();
				
				
				
				return;
				
			}
		}
		//if (Input.GetTouch (0).phase == TouchPhase.Began) 
		//{
		//Instantiate(lightsnow, snow.position, snow.rotation);
		//Application.LoadLevel ("main");
		//load.text = "Loading . . .";
		//}
	}
}
