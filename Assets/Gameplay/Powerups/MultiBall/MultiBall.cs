using UnityEngine;
using System.Collections;

public class MultiBall : BasePowerup {
	
	public Transform prefab;
	private GameObject newBall;
	
	new void Start() {
		
		base.Start();
		
	}
	
	new void Update() {
		
		base.Update();
		
		if(removePowerup){
			
			PowerupManager.setPowerupOnScreen(false);

			removePowerup = false;

			Destroy(newBall);

			Destroy(gameObject);
		}
		
	}
	
	public override void activate()
	{
		if (ball != null) {
			
			activated = true; //Powerup was actually activated (ball hit it)
			
			newBall = ((Transform) Instantiate (prefab, new Vector3 (0f, 0f, 0f), new Quaternion (0f, 0f, 0f, 0f))).gameObject;

			ball.addCurrentSpeed(newBall);
		}
	}
}
