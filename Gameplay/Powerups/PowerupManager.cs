using UnityEngine;
using System.Collections;

enum powerupType
{
	speedUp = 0
};

public class PowerupManager : MonoBehaviour
{
	//array containing all of the prefabs for powerups, set in inspector
	//ORDER MATTERS. pay attention to the above enum
	public BasePowerup[] prefabs;
	
	//bounding values for spawning a powerup, set in inspector
	public float upperLimit;
	public float lowerLimit;
	public float leftLimit;
	public float rightLimit;
	
	void Start()
	{
		//this is placeholder, we still need to write code to randomly spawn powerups
		createNewPowerup(powerupType.speedUp);
	}
	
	void Update()
	{
	
	}
	
	//creates a powerup of the specified type at a random location
	private void createNewPowerup(powerupType type)
	{
		Vector3 powerupLocation = new Vector3(Random.Range(leftLimit, rightLimit), Random.Range(lowerLimit, upperLimit), 0);
		
		switch(type)
		{
			case powerupType.speedUp:
				Instantiate(prefabs[0], powerupLocation, new Quaternion(0f, 0f, 0f, 0f));
				break;
			
			default:
				throw new System.ArgumentException("invalid powerup type");
		};
	}
}
