using UnityEngine;
using System.Collections;

public class ComputerPlayer : Player
{
	public Rigidbody ball;
	public bool smarterAI;
	public int smartness;
	
	private Vector3 destination;
	
	void Start()
	{
	
	}
	
	void Update()
	{
		if(!smarterAI)
		{
			easyMode(ball.position);
		}
		else
		{
			hardMode();
		}
	}
	
	private void easyMode(Vector3 dest)
	{
		//If the ball is above the computer player, move up without leaving the playing area
		if(dest.y > transform.position.y)
		{
			transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);	
		}
		if(transform.position.y > topBounds)
		{
			//temp vector used because C# is picky about modifying single components of properties
			Vector3 temp = new Vector3(transform.position.x, topBounds, transform.position.z);
			transform.position = temp;	
		}
		
		//If the ball is below the computer player, move down without leaving the playing area
		if(dest.y < transform.position.y)
		{
			transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);	
		}
		if(transform.position.y < bottomBounds)
		{
			//temp vector used because C# is picky about modifying single components of properties
			Vector3 temp = new Vector3(transform.position.x, bottomBounds, transform.position.z);
			transform.position = temp;	
		}
	}
	
	private void hardMode()
	{
		if(destination != null)
		{
			
		}
		else
		{
			easyMode(ball.position);
		}
	}
}
