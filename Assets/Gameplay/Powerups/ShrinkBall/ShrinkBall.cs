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
	
	void Start () {
		
		base.Start();
		
		sizeModifier = new Vector3(0.4f,0.4f,0.4f);
		growSize = new Vector3(0.05f,0.05f,0.05f);
		growTimerLimit = 0.3f;
		growTimer = growTimerLimit;
		
	}
	
	void Update(){
		
		base.Update();
		
		//If powerup's time is over, set the ball back to normal and destroy powerup
		if(removePowerup){
			
			if(growTimer > 0){
	  			growTimer -= Time.deltaTime;
	 		}
			else{
				ball.changeSize(ball.renderer.bounds.size + growSize); //Progressively grows ball back to normal
				growTimer = growTimerLimit;
			}
			
			//If ball's size is back to normal, destroy powerup
			if(ball.renderer.bounds.size == originalSize){
				
				ball.changeMaterial(Color.white);
				
				PowerupManager.setPowerupOnScreen(false);
				Destroy(gameObject);
				
				removePowerup = false;
				Debug.Log("End of Powerup!");
				
			}
			
		}
		
	}
	
	public override void activate()
	{
		if(childActivated) return;
		
		Debug.Log("-Shrink Ball- Powerup!");
		
		originalSize = ball.renderer.bounds.size;
		
		ball.changeSize(sizeModifier);
		ball.changeMaterial(Color.yellow);
		
		childActivated = true;
	}
}
