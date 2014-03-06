using UnityEngine;
using System.Collections;

enum powerupType
{
	speedUp = 0,
	shrinkBall = 1,
	growShield = 2,
	multiBall = 3
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
	public int maxActivePowerUps;
	private static int numActivePowerUps;
	
	void Start()
	{
		powerupTimerLimit = 5f;
		powerupTimer = powerupTimerLimit;
		numActivePowerUps = 0;
		
		//this is placeholder, we still need to write code to randomly spawn powerups
		createNewPowerup((powerupType)3);
	}
	
	void Update()
	{
		if(powerupTimer > 0){
  			powerupTimer -= Time.deltaTime;
 		}
		else{
			//Debug.Log("time up!");
			if(numActivePowerUps <= maxActivePowerUps){//if there's no powerup showing up, it's time to create a new random powerup
				createNewPowerup((powerupType)Random.Range(0, 4));
			}
			
			powerupTimer = powerupTimerLimit;//reseting the powerup timer
		}

	}
	
	//creates a powerup of the specified type at a random location
	private void createNewPowerup(powerupType type)
	{
		int typeValue = (int)type;//just converting the enum to an int so we can compare it, address it and so on...
		
		Vector3 powerupLocation = calculatePosition();
		//checking if the type of the power up is into the powerup array
		if(typeValue < prefabs.Length){
			Instantiate(prefabs[typeValue], powerupLocation, new Quaternion(0f, 0f, 0f, 0f));
		}
		else{
			throw new System.ArgumentException("invalid powerup type");
		}
		numActivePowerUps++;
	}

	private Vector3 calculatePosition(){

		Vector3 powerupLocation = new Vector3(Random.Range(leftLimit, rightLimit), Random.Range(lowerLimit, upperLimit), 0);
		var existingObjs = Physics.OverlapSphere(powerupLocation, 1.5f);
		if(existingObjs.Length > 0){
			return calculatePosition();
		}
		return powerupLocation;
	}
	
	//Used by 'BasePowerup' class. When false, it decreases numActivePowerUps
	public static void setPowerupOnScreen(bool value){
		if(!value) {
			numActivePowerUps--;
		}
	}
}
