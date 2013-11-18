using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GUISkin guiStyle;
	public int bezel;
	
	void OnGUI() {
		GUI.skin = guiStyle;
        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
        if(GUI.Button(new Rect(Screen.width * 0.05f, Screen.height * 0.05f, Screen.width * 0.425f, Screen.height * 0.6f), "Single Player")) {
			Application.LoadLevel("MainGame");	
		}
		
		if(GUI.Button(new Rect(Screen.width * 0.525f, Screen.height * 0.05f, Screen.width * 0.425f, Screen.height * 0.6f), "Multi-Player")) {
			//Load multiplayer portion using this format:
			//Application.LoadLevel("Multiplayer");	
		}
		
		if(GUI.Button(new Rect(Screen.width * 0.05f, Screen.height * 0.7f, Screen.width * 0.425f, Screen.height * 0.25f), "Options")) {
			//Load the options menu if we get around to it (Difficulty for SP, sound level, etc)
			//Application.LoadLevel("Option");	
		}
		
		if(GUI.Button(new Rect(Screen.width * 0.525f, Screen.height * 0.7f, Screen.width * 0.425f, Screen.height * 0.25f), "Credits")) {
			//Because we need to be recognised for our hard work
			//Application.LoadLevel("MainGame");	
		}
        GUI.EndGroup();
    }
}
