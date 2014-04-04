using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {


	public GUISkin guiStyle;
	private string currentMenu;
	private GameObject options;

	//Options menu values
	private float volumeValue;

	//Powerups menu values
	private bool speedUpToggle;
	private bool shrinkBallToggle;
	private bool growShieldToggle;

	private float speedUpValue;
	private float shrinkBallValue;
	private float growShieldValue;

	void Start() {
		options = GameObject.FindGameObjectWithTag("OptionsContainer");
		Time.timeScale = 2f;
		currentMenu = "main";
		loadOptions();
		loadPowerUps();
	}

	void Update() {
		if (currentMenu == "options") {
			saveOptions();
		}
	}
	
	void OnGUI() {
		GUI.skin = guiStyle;
        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));

		if(currentMenu == "main") {
	        if(GUI.Button(new Rect(Screen.width * 0.05f, Screen.height * 0.05f, Screen.width * 0.425f, Screen.height * 0.6f), "SINGLE PLAYER")) {
				Application.LoadLevel("MainGame");	
			}
			
			if(GUI.Button(new Rect(Screen.width * 0.525f, Screen.height * 0.05f, Screen.width * 0.425f, Screen.height * 0.6f), "MULTI PLAYER")) {
				Application.LoadLevel("Multiplayer");	
			}
			
			if(GUI.Button(new Rect(Screen.width * 0.05f, Screen.height * 0.7f, Screen.width * 0.425f, Screen.height * 0.25f), "OPTIONS")) {
				//Load Options
				currentMenu = "options";
			}
			
			if(GUI.Button(new Rect(Screen.width * 0.525f, Screen.height * 0.7f, Screen.width * 0.425f, Screen.height * 0.25f), "CREDITS")) {
				//Because we need to be recognised for our hard work
				currentMenu = "credits";

			}
		} else if(currentMenu == "options") {
			optionsMenu();
		}else if(currentMenu == "powerups") {
			powerUpMenu();
		}else if(currentMenu == "credits") {
			creditsMenu();
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
		GUI.Box(new Rect(Screen.width * 0.05f,Screen.height * 0.05f,Screen.width * 0.90f,Screen.height * 0.90f), "POWERUP OPTIONS");


		//Toggles
		speedUpToggle = 	GUI.Toggle (new Rect (Screen.width * 0.1f, Screen.height * 0.20f, Screen.width * 0.35f, 30), speedUpToggle, "SPEED UP");
		shrinkBallToggle = 	GUI.Toggle (new Rect (Screen.width * 0.1f, Screen.height * 0.28f, Screen.width * 0.35f, 30), shrinkBallToggle, "SHRINK BALL");
		growShieldToggle = 	GUI.Toggle (new Rect (Screen.width * 0.1f, Screen.height * 0.36f, Screen.width * 0.35f, 30), growShieldToggle, "GROW SHIELD");

		speedUpValue = 		GUI.HorizontalSlider(new Rect(Screen.width * 0.5f, Screen.height * 0.22f, Screen.width * 0.35f, 30), speedUpValue, 0.5F, 1.5F);
		shrinkBallValue = 	GUI.HorizontalSlider(new Rect(Screen.width * 0.5f, Screen.height * 0.30f, Screen.width * 0.35f, 30), shrinkBallValue, 1.5F, 0.5F);
		growShieldValue =	GUI.HorizontalSlider(new Rect(Screen.width * 0.5f, Screen.height * 0.38f, Screen.width * 0.35f, 30), growShieldValue, 0.5F, 1.5F);

		//Cancel Button
		if(GUI.Button(new Rect(Screen.width * 0.5f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.1f), "CANCEL")) {
			//Return to options menu
			loadPowerUps();
			currentMenu = "options";
		}
		
		//Save Options Button
		if(GUI.Button(new Rect(Screen.width * 0.725f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.1f), "SAVE")) {
			//Save and return to options menu
			savePowerUps();
			currentMenu = "options";
		}
	}
	
	void creditsMenu() {
		GUI.Box(new Rect(Screen.width * 0.05f,Screen.height * 0.05f,Screen.width * 0.90f,Screen.height * 0.90f), "CREDITS");
		
		//credits list
		GUI.Label(new Rect(Screen.width * 0.25f,Screen.height * 0.15f,Screen.width * 0.5f,Screen.height * 0.1f), "Lead Programmer");
		GUI.Label(new Rect(Screen.width * 0.25f,Screen.height * 0.22f,Screen.width * 0.5f,Screen.height * 0.1f), "Jake Stephens");
		GUI.Label(new Rect(Screen.width * 0.25f,Screen.height * 0.32f,Screen.width * 0.5f,Screen.height * 0.1f), "Additional Programming");
		GUI.Label(new Rect(Screen.width * 0.25f,Screen.height * 0.39f,Screen.width * 0.5f,Screen.height * 0.1f), "Brian Dinelt");
		GUI.Label(new Rect(Screen.width * 0.25f,Screen.height * 0.45f,Screen.width * 0.5f,Screen.height * 0.1f), "Thais Correia");
		GUI.Label(new Rect(Screen.width * 0.25f,Screen.height * 0.52f,Screen.width * 0.5f,Screen.height * 0.1f), "Francisco Ari Josino");
		
		//Back Button
		if(GUI.Button(new Rect(Screen.width * 0.325f, Screen.height * 0.65f, Screen.width * 0.35f, Screen.height * 0.25f), "MAIN MENU")) {
			//Return to main menu
			currentMenu = "main";
		}
	}

	//Load option values from OptionsContainer
	void loadOptions() {
		volumeValue = 	options.GetComponent<OptionsContainer>().volumeValue;
	}

	//Save option values from OptionsContainer
	void saveOptions() {
		options.GetComponent<OptionsContainer>().volumeValue = volumeValue;
	}

	//Load option values from OptionsContainer
	void loadPowerUps() {
		speedUpToggle = 	options.GetComponent<OptionsContainer>().toggles[0];
		shrinkBallToggle = 	options.GetComponent<OptionsContainer>().toggles[1];
		growShieldToggle = 	options.GetComponent<OptionsContainer>().toggles[2];
		
		speedUpValue =	 	options.GetComponent<OptionsContainer>().values[0];
		shrinkBallValue =	options.GetComponent<OptionsContainer>().values[1];
		growShieldValue = 	options.GetComponent<OptionsContainer>().values[2];
	}

	//Save option values to OptionsContainer
	void savePowerUps() {
		options.GetComponent<OptionsContainer>().toggles[0] = speedUpToggle;
		options.GetComponent<OptionsContainer>().toggles[1] = shrinkBallToggle;
		options.GetComponent<OptionsContainer>().toggles[2] = growShieldToggle;
		
		options.GetComponent<OptionsContainer>().values[0] = speedUpValue;
		options.GetComponent<OptionsContainer>().values[1] = shrinkBallValue;
		options.GetComponent<OptionsContainer>().values[2] = growShieldValue;
	}
}
