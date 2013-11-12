using UnityEngine;
using System.Collections;

public class SpeedUp : BasePowerup
{

	void Start()
	{
	
	}
	
	public override void activate(GameObject ball)
	{
		ball.GetComponent<Ball>().changeBallSpeed(2.5f);	
	}
}
