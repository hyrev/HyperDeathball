using UnityEngine;
using System.Collections;

//all powerups must inherit from this base class
public class BasePowerup : MonoBehaviour
{
	public Vector3 rotationVelocity;

	void Start()
	{
		
	}
	
	void Update() 
	{
		transform.Rotate(rotationVelocity * Time.deltaTime);
	}
	
	void OnTriggerEnter(Collider c)
	{
		activate(c.gameObject);
		Destroy(gameObject);
	}
	
	//DO NOT CALL THIS FUNCTION DIRECTLY
	//when making a new powerup, you MUST override this function!
	public virtual void activate(GameObject ball)
	{
		throw new System.MethodAccessException("You are not overriding virtual method 'activatePowerup' correctly");
	}
}
