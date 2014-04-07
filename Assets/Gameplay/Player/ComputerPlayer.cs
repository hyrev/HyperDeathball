using UnityEngine;
using System.Collections;

public class ComputerPlayer : Player
{
	public Rigidbody ball;
	public bool smarterAI;
	public int smartness;
	
	private Vector3 destination;
	private readonly Vector3 nDest = new Vector3(0, 0, 0);
	
	void Start()
	{
		destination = nDest;
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
	
	public void recalculateDestination()
	{
		Vector3 tempBallPos = ball.position;
		Vector3 tempBallDir = GameObject.Find("Ball").rigidbody.velocity;
		
		for(int x = 0; x < smartness; x++)
		{
			//fire a ray from the current temp point
			Ray ray = new Ray(tempBallPos, tempBallDir);
			RaycastHit hit = new RaycastHit();
			
			//check what the ray hit, and if it hit a wall, continue
			//if it hit the computer's area, go to that position
			if(Physics.Raycast(ray, out hit, 50))
			{
				if(hit.collider.gameObject.name.CompareTo("TopBound") == 0 ||
				   hit.collider.gameObject.name.CompareTo("BottomBound") == 0)
			    {
			   		tempBallPos = hit.point;
			   		tempBallDir = Vector3.Reflect(tempBallDir, hit.normal);
			    }
				else if(hit.collider.gameObject.name.CompareTo("ComputerArea") == 0 ||
						hit.collider.gameObject.name.CompareTo("Player2") == 0)
				{
					destination = hit.point;
					break;
				}
				else
				{
					tempBallPos = hit.point + (tempBallDir.normalized);
				}
			}
		}
	}
	
	public void resetDestination()
	{
		destination = nDest;
	}
	
	private void hardMode()
	{
		if(destination != nDest)
		{
			easyMode(destination);
		}
		else
		{
			easyMode(ball.position);
		}
	}
}
