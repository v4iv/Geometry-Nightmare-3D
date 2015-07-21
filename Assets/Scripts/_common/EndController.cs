using UnityEngine;
using System.Collections;

public class EndController : MonoBehaviour {

	public GUIText finalScore;
	public int t;

	// Use this for initialization
	void Awake () {
		t=PlayerPrefs.GetInt ("TempScore");
		finalScore.text = "Final Score : " + t;
		PlayerPrefs.DeleteKey ("TempScore");
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
