using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GUISkin guiStyle;
	private string currentMenu;
	float volumeValue = 0.5f;

	void Start() {
		currentMenu = "main";
	}
	
	void OnGUI() {
		GUI.skin = guiStyle;
        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));

		if(currentMenu == "main") {
	        if(GUI.Button(new Rect(Screen.width * 0.05f, Screen.height * 0.05f, Screen.width * 0.425f, Screen.height * 0.6f), "SINGLE PLAYER")) {
				Application.LoadLevel("MainGame");	
			}
			
			if(GUI.Button(new Rect(Screen.width * 0.525f, Screen.height * 0.05f, Screen.width * 0.425f, Screen.height * 0.6f), "MULTI PLAYER")) {
				//Load multiplayer portion using this format:
				//Application.LoadLevel("Multiplayer");	
			}
			
			if(GUI.Button(new Rect(Screen.width * 0.05f, Screen.height * 0.7f, Screen.width * 0.425f, Screen.height * 0.25f), "OPTIONS")) {
				//Load Options
				currentMenu = "options";
			}
			
			if(GUI.Button(new Rect(Screen.width * 0.525f, Screen.height * 0.7f, Screen.width * 0.425f, Screen.height * 0.25f), "CREDITS")) {
				//Because we need to be recognised for our hard work

			}
		} else if(currentMenu == "options") {
			optionsMenu();
		}else if(currentMenu == "powerups") {

		}
        GUI.EndGroup();
    }

	void optionsMenu() {
		GUI.Box(new Rect(Screen.width * 0.05f,Screen.height * 0.05f,Screen.width * 0.90f,Screen.height * 0.90f), "OPTIONS MENU");

		//Volume Slider
		GUI.Label (new Rect (Screen.width * 0.4f, Screen.height * 0.2f, Screen.width * 0.2f, 25), "VOLUME");
		volumeValue = GUI.HorizontalSlider(new Rect(Screen.width * 0.3f, Screen.height * 0.3f, Screen.width * 0.4f, 30), volumeValue, 0.0F, 1.0F);

		//Back Button
		if(GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.5f, Screen.width * 0.35f, Screen.height * 0.25f), "MAIN MENU")) {
			//Return to main menu
			currentMenu = "main";
		}

		//Powerup Options Button
		if(GUI.Button(new Rect(Screen.width * 0.55f, Screen.height * 0.5f, Screen.width * 0.35f, Screen.height * 0.25f), "POWERUP OPTIONS")) {
			currentMenu = "powerups";
		}
	}

	void powerUpMenu() {
		//Temporarily go to main menu
		currentMenu = "main";
	}
}
