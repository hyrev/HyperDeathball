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
	public static int numActivated;
	
	public static Ball ball;
	
	//Call this function from subclass: base.Start()
	public void Start()
	{
		if(!activated){
		
			timerLimit = 10f;
			removePowerup = false;
			activated = false;
			timer = timerLimit;
		}
	}
	
	//Call this function from subclass: base.Update()
	public void Update()
	{
		transform.Rotate(rotationVelocity * Time.deltaTime);
		
		if(activated)
		{ //Setting a timer for powerups, so the ball can go back to normal
			if(timer > 0){
	  			timer -= Time.deltaTime;
	 		}
			else{
				removePowerup = true;
				activated = false;
			}
		}
	}
	
	void OnTriggerEnter(Collider c)
	{
		if(!activated)
		{			
			ball = c.gameObject.GetComponent<Ball>();
			
			timer = timerLimit;
			
			activate();
			
			//get the GrameObject and Component for the GridManager
			GameObject grid = GameObject.Find("GridManager");
			GridManager manager = grid.GetComponent<GridManager>();
			
			//cast a ray from the camera, through the powerup, to the Grid-Plane
			Ray r = new Ray(Camera.main.transform.localPosition, transform.localPosition - Camera.main.transform.localPosition);
			Plane p = new Plane(new Vector3(0, 0, -1), grid.transform.localPosition);
			float f;
			p.Raycast(r, out f);
			
			//convert the ray-plane intersection into grid coordinates
			int gridHalfWidth = (int)(manager.gridWidth * manager.cubeXOffset / 2);
			int gridHalfHeight = (int)(manager.gridHeight * manager.cubeYOffset / 2);
			int gridPosX = (int)(((r.direction * f).x + gridHalfWidth) / manager.cubeXOffset);
			int gridPosY = manager.gridHeight - (int)(((r.direction * f).y + gridHalfHeight) / manager.cubeYOffset);
			
			//send a grid pulse from this location
			manager.gridPulseFromLocation(gridPosX, gridPosY);
			
			//Setting visibility to false, powerup is destroyed only after its time is over.
			gameObject.renderer.enabled = false;
		}
	}
	
	//DO NOT CALL THIS FUNCTION DIRECTLY
    //when making a new powerup, you MUST override this function!
	public virtual void activate()
	{
		throw new System.MethodAccessException("You are not overriding virtual method 'activate' correctly");
	}
}
