using UnityEngine;
using System.Collections;

public class SpeedUp : BasePowerup
{
	public float speedModifier;
	
	void Start()
	{
		base.Start();
		
		speedModifier = 2.5f;
	}
	
	void Update()
	{
		base.Update();
		
		//If powerup's time is over, set the ball back to normal and destroy powerup
		if(removePowerup){
			
			ball.changeSpeed(-speedModifier);
			ball.changeMaterial(Color.white);
			
			PowerupManager.setPowerupOnScreen(false);
			Destroy(gameObject);
			
			removePowerup = false;
			Debug.Log("End of Powerup!");
			
		}
	}
	
	public override void activate()
	{
		if(!childActivated)
		{
			Debug.Log("-Speed Up- Powerup!");
			
			ball.changeSpeed(speedModifier);
			ball.changeMaterial(Color.red);
			
			childActivated = true;
		}
	}
}
