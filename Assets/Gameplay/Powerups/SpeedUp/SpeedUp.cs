using UnityEngine;
using System.Collections;

public class SpeedUp : BasePowerup
{
	public float speedModifier;
	
	new void Start()
	{
		base.Start();
		
		speedModifier = 2.5f;
	}
	
	new void Update()
	{
		base.Update();
		
		//If powerup's time is over, set the ball back to normal and destroy powerup
		if(removePowerup){
			
			ball.changeSpeed(-speedModifier);
			ball.changeMaterial(Color.white, numActivated);
			
			PowerupManager.setPowerupOnScreen(false);
			Destroy(gameObject);
			
			removePowerup = false;
			//Debug.Log("-Speed Up- End of Powerup!");
			
		}
	}
	
	public override void activate()
	{
		activated = true; //Powerup was actually activated (ball hit it)
		++numActivated;
		//Debug.Log("-Speed Up- Powerup!");
		
		ball.changeSpeed(speedModifier);
		ball.changeMaterial(Color.red);
	}
}
