using UnityEngine;
using System.Collections;

public class ShrinkBall : BasePowerup 
{
	public static Vector3 originalSize;
	public Vector3 sizeModifier;
	public Vector3 growSize;
	public Vector3 shrinkSize;
	
	public float growTimerLimit;
	public float growTimer;
	
	new void Start () {
		
		base.Start();

		float optionsModifier = GameObject.Find ("OptionsContainer").GetComponent<OptionsContainer>().values[1];
		sizeModifier = new Vector3(0.4f,0.4f,0.4f);
		sizeModifier = sizeModifier * optionsModifier;
		growSize = new Vector3(0.05f,0.05f,0.05f);
		originalSize = new Vector3(1.0f,1.0f,1.0f);
		growTimerLimit = 0.3f;
		growTimer = growTimerLimit;
		
	}
	
	new void Update(){
		
		base.Update();
		
		//If powerup's time is over, set the ball back to normal and destroy powerup
		if(removePowerup){

			if(ball != null){
			
				if(growTimer > 0){
		  			growTimer -= Time.deltaTime;
		 		}
				else{
					ball.changeSize(ball.renderer.bounds.size + growSize); //Progressively grows ball back to normal
					growTimer = growTimerLimit;
				}
				
				//If ball's size is back to normal, destroy powerup
				if(ball.renderer.bounds.size == originalSize){
					
					ball.removePowerUp("ShrinkBall");

					ball.changeMaterial(Color.white);
					
					removePowerup = false;

					PowerupManager.setPowerupOnScreen(false);

					Destroy(gameObject);
					
				}

			}else{

				PowerupManager.setPowerupOnScreen(false);
				removePowerup = false;
				Destroy(gameObject);

			}
			
		}
		
	}
	
	public override void activate()
	{
		if(!ball.containsPowerUp("ShrinkBall") && ball != null)
		{
			activated = true; //Powerup was actually activated (ball hit it)
		
			//Debug.Log("-Shrink Ball- Powerup!");
			
			ball.changeSize(sizeModifier);
			ball.changeMaterial(Color.yellow);

			ball.addPowerUp("ShrinkBall");
		}
	}
}
