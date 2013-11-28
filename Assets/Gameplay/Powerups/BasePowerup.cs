using UnityEngine;
using System.Collections;

//All powerups must inherit from this base class
public class BasePowerup : MonoBehaviour
{
	public Vector3 rotationVelocity;
	
	public float timerLimit;
	public float timer;
	
	public bool removePowerup;
	public bool activated;
	public bool childActivated;
	
	public static Ball ball;
	
	//Call this function from subclass: base.Start()
	public void Start()
	{
		if(activated) return;
		
		timerLimit = 10f;
		removePowerup = false;
		activated = false;
		childActivated = false;
		timer = timerLimit;
	}
	
	//Call this function from subclass: base.Update()
	public void Update()
	{
		transform.Rotate(rotationVelocity * Time.deltaTime);
		
		if(!activated) return;
		
		//Setting a timer for powerups, so the ball can go back to normal
		if(timer > 0){
  			timer -= Time.deltaTime;
 		}
		else{
			removePowerup = true;
			activated = false;
		}
	}
	
	void OnTriggerEnter(Collider c)
	{
		if(activated) return;
		
		ball = c.gameObject.GetComponent<Ball>();
		
		timer = timerLimit;
		activated = true; //Powerup was actually activated (ball hit it)
		
		activate();
		
		//Setting visibility to false, powerup is destroyed only after its time is over.
		gameObject.renderer.enabled = false;
	}
	
	//DO NOT CALL THIS FUNCTION DIRECTLY
    //when making a new powerup, you MUST override this function!
	public virtual void activate()
	{
		throw new System.MethodAccessException("You are not overriding virtual method 'activatePowerup' correctly");
	}
}
