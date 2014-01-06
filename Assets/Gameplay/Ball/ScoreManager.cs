using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	public int winningScore;

	private int player1Score;
	private int player2Score;


	void Start()
	{
		player1Score = 0;
		player2Score = 0;
	}
	
	void Update()
	{
		//player 1 wins
		if(player1Score >= winningScore)
		{
		
		}
		
		//player 2 wins
		if(player2Score >= winningScore)
		{
		
		}
	}
	
	public void player1Scores()
	{
		player1Score++;
	}
	
	public void player2Scores()
	{
		player2Score++;
	}
}
