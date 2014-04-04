using UnityEngine;
using System.Collections;

public class SpeedUp : BasePowerup
{
	public float speedModifier;
	
	new void Start()
	{
		base.Start();
		float optionsModifier = GameObject.Find ("OptionsContainer").GetComponent<OptionsContainer>().values[0];
		speedModifier = optionsModifier * 2.5f;
	}
	
	new void Update()
	{
		base.Update();
		
		//If powerup's time is over, set the ball back to normal and destroy powerup
		if(removePowerup){

			if(ball != null){
			
				ball.removePowerUp("SpeedUp");

				ball.changeSpeed(-speedModifier);
				ball.changeMaterial(Color.white);
				
				removePowerup = false;

				PowerupManager.setPowerupOnScreen(false);
				Destroy(gameObject);

			}
			else{
				removePowerup = false;
				
				PowerupManager.setPowerupOnScreen(false);
				Destroy(gameObject);
			}
			
		}
	}
	
	public override void activate()
	{
		if (ball != null) {
			//Debug.Log("-SpeedUp- Powerup!");
			activated = true; //Powerup was actually activated (ball hit it)
			ball.changeMaterial (Color.red);

			ball.changeSpeed (speedModifier);

			ball.addPowerUp("SpeedUp");
			audio.Play();
		}
	}
}
