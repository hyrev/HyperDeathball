using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	public GUISkin guiStyle;
	public Texture pauseButtonImage;
	public bool isPaused = false;
	
	void Update() {
		//Maybe put stuff here. Probably not
	}
	
	void OnGUI() {
		GUI.skin = guiStyle;
        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
		
		//Pause button
        if(GUI.Button(new Rect(Screen.width * 0.95f, Screen.height  * 0.05f, 30, 30), pauseButtonImage)) {
			isPaused = togglePause();	
		}
		
		//Pause Menu
		if(isPaused) {
			if(GUI.Button(new Rect(Screen.width * 0.10f, Screen.height * 0.10f, Screen.width * 0.35f, Screen.height * 0.80f), "OPTIONS")) {
				//Load up the Options menu
			}
			
			if(GUI.Button(new Rect(Screen.width * 0.55f, Screen.height * 0.10f, Screen.width * 0.35f, Screen.height * 0.80f), "MAIN MENU")) {
				Application.LoadLevel("MainMenu");	
			}
		}
		GUI.EndGroup();
	}
	
	bool togglePause() {
		if(Time.timeScale == 0f) {
			Time.timeScale = 2f;
			return(false);
		} else {
			Time.timeScale = 0f;
			return(true);    
		}
	}
}