using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	public int winningScore;

	private int player1Score;
	private int player2Score;
	
	private bool flag_start;


	void Start()
	{
		player1Score = 0;
		player2Score = 0;
		flag_start = true;
	}
	
	void Update()
	{
		if(flag_start)
		{
			GridManager grid = GameObject.Find("GridManager").GetComponent<GridManager>();
			grid.setScoreForPlayer(player1Score, 1);
			grid.setScoreForPlayer(player2Score, 2);
			
			flag_start = false;
		}
		//player 1 wins
		if(player1Score >= winningScore)
		{
			this.GetComponent<GameOver>().gameOver(true);
		}
		
		//player 2 wins
		if(player2Score >= winningScore)
		{
			this.GetComponent<GameOver>().gameOver(false);
		}
	}
	
	public void player1Scores()
	{
		player1Score++;
		GridManager grid = GameObject.Find("GridManager").GetComponent<GridManager>();
		grid.setScoreForPlayer(player1Score, 1);
	}
	
	public void player2Scores()
	{
		player2Score++;
		GridManager grid = GameObject.Find("GridManager").GetComponent<GridManager>();
		grid.setScoreForPlayer(player2Score, 2);
	}
}
