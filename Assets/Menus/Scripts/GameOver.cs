using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour 
{
	
	public GUISkin guiStyle;
	private string winnerText;
	private bool guiEnable;
	
	void Start()
	{
		guiEnable = false;
	}
	
	void Update() 
	{

	}
	
	void OnGUI()
	{
		if(guiEnable)
		{
			GUI.skin = guiStyle;
			GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
			
			GUI.Box(new Rect(Screen.width * 0.05f,Screen.height * 0.05f,Screen.width * 0.90f,Screen.height * 0.90f), winnerText);
			if(GUI.Button(new Rect(Screen.width * 0.25f, Screen.height * 0.50f, Screen.width * 0.50f, Screen.height * 0.25f), "MAIN MENU")) 
			{
				Application.LoadLevel("MainMenu");	
			}
			
			GUI.EndGroup();
		}
	}
	
	public void gameOver(bool player1Wins)
	{
		winnerText = "PLAYER 2 WINS";
		if(player1Wins)
		{
			winnerText = "PLAYER 1 WINS";
		}
	
		Time.timeScale = 0f;
		guiEnable = true;
	}
}