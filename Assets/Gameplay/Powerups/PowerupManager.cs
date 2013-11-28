using UnityEngine;
using System.Collections;

enum powerupType
{
	speedUp = 0,
	shrinkBall = 1
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
	public float powerupTimerLimit;
	public float powerupTimer;
	private static bool powerupOnScreen;
	
	void Start()
	{
		powerupTimerLimit = 5f;
		powerupTimer = powerupTimerLimit;
		
		//this is placeholder, we still need to write code to randomly spawn powerups
		createNewPowerup(powerupType.speedUp);
	}
	
	void Update()
	{
		if(powerupTimer > 0){
  			powerupTimer -= Time.deltaTime;
 		}
		else{
			//Debug.Log("time up!");
			if(!powerupOnScreen){//if there's no powerup showing up, it's time to create a new random powerup
				createNewPowerup((powerupType)Random.Range(0, 2));
			}
			
			powerupTimer = powerupTimerLimit;//reseting the powerup timer
		}

	}
	
	//creates a powerup of the specified type at a random location
	private void createNewPowerup(powerupType type)
	{
		int typeValue = (int)type;//just converting the enum to an int so we can compare it, address it and so on...
		
		Vector3 powerupLocation = new Vector3(Random.Range(leftLimit, rightLimit), Random.Range(lowerLimit, upperLimit), 0);
		//checking if the type of the power up is into the powerup array
		if(typeValue < prefabs.Length){
			Instantiate(prefabs[typeValue], powerupLocation, new Quaternion(0f, 0f, 0f, 0f));
		}
		else{
			throw new System.ArgumentException("invalid powerup type");
		}
		
		powerupOnScreen = true;
		
//		switch(type)
//		{
//			case powerupType.speedUp:
//				Instantiate(prefabs[0], powerupLocation, new Quaternion(0f, 0f, 0f, 0f));
//				break;
//			case powerupType.shrinkBall:
//				Instantiate(prefabs[1], powerupLocation, new Quaternion(0f, 0f, 0f, 0f));
//				break;
//			
//			default:
//				throw new System.ArgumentException("invalid powerup type");
//		};
	}
	
	//Used by 'BasePowerup' class. It sets powerupOnScreen to false before destroying the powerup, so a new powerup can be created
	public static void setPowerupOnScreen(bool value){
		powerupOnScreen = value;
	}
}
