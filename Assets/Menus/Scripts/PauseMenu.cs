using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	public GUISkin guiStyle;
	public Texture pauseButtonImage;
	public bool isPaused = false;

	private string currentMenu;
	private float volumeValue;

	void Start() {
		loadOptions ();
		currentMenu = "pause";
	}
	
	void Update() {
		if (currentMenu == "options") {
			saveOptions();
		}
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
			if(currentMenu == "pause") {
				if(GUI.Button(new Rect(Screen.width * 0.10f, Screen.height * 0.10f, Screen.width * 0.35f, Screen.height * 0.80f), "OPTIONS")) {
					currentMenu = "options";
				}
			
				if(GUI.Button(new Rect(Screen.width * 0.55f, Screen.height * 0.10f, Screen.width * 0.35f, Screen.height * 0.80f), "MAIN MENU")) {
					isPaused = togglePause();
					Application.LoadLevel("MainMenu");	
				}
			} else if(currentMenu == "options") {
				GUI.Box(new Rect(Screen.width * 0.05f,Screen.height * 0.05f,Screen.width * 0.90f,Screen.height * 0.90f), "OPTIONS MENU");
				
				//Volume Slider
				GUI.Label (new Rect (Screen.width * 0.4f, Screen.height * 0.2f, Screen.width * 0.2f, 25), "VOLUME");
				volumeValue = GUI.HorizontalSlider(new Rect(Screen.width * 0.3f, Screen.height * 0.3f, Screen.width * 0.4f, 30), volumeValue, 0.0F, 1.0F);
				
				//Back Button
				if(GUI.Button(new Rect(Screen.width * 0.3f, Screen.height * 0.5f, Screen.width * 0.4f, Screen.height * 0.25f), "BACK")) {
					//Return to pause menu
					currentMenu = "pause";
				}
			}
		}
		GUI.EndGroup();
	}

	//Load option values from OptionsContainer
	void loadOptions() {
		volumeValue = 	GameObject.FindGameObjectWithTag("OptionsContainer").GetComponent<OptionsContainer>().volumeValue;
	}
	
	//Save option values from OptionsContainer
	void saveOptions() {
		GameObject.FindGameObjectWithTag("OptionsContainer").GetComponent<OptionsContainer>().volumeValue = volumeValue;
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