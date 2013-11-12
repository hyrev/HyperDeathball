using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	//default values set in inspector
	public float speed;
	public float bounceIncrement;
	public int leftScorePosition;
	public int rightScorePosition;
	
	//angle stored as DEGREES, convert to radians when necessary
	private float currentAngle;
	
	private GameObject lastCollidedPlayer;

	void Start()
	{
		//initialize the velocity of the ball based on the preset speed and a randomly generated angle
		currentAngle = Random.Range(150, 170);
		rigidbody.velocity = calculateVelocity(speed, currentAngle);

	}
	
	void FixedUpdate()
	{
		//ball has entered left player's net
		if(transform.position.x < leftScorePosition)
		{
			currentAngle = Random.Range(15, 30);
			transform.position = new Vector3(0, 0, 0);
			rigidbody.velocity = calculateVelocity(speed, currentAngle);
		}
		
		//ball has entered right player's net
		if(transform.position.x > rightScorePosition)
		{
			currentAngle = Random.Range(150, 165);
			transform.position = new Vector3(0, 0, 0);
			rigidbody.velocity = calculateVelocity(speed, currentAngle);
		}
	}
	
	void OnCollisionEnter(Collision c)
	{
		//keep track of the last person to hit the ball (for powerups etc)
		if(c.gameObject.name.CompareTo("Player1") == 0 || c.gameObject.name.CompareTo("Player2") == 0)
		{
			lastCollidedPlayer = c.gameObject;
		}
	}
	
	void OnCollisionExit(Collision c)
	{
		//after colliding, recalculate the direction the ball is going
		currentAngle = calculateDirection(rigidbody.velocity.x, rigidbody.velocity.y);

		//increase ball speed
		changeBallSpeed(bounceIncrement);
	}
	
	//do not access the lastPlayer directly, use this
	public GameObject getLastPlayer()
	{
		return lastCollidedPlayer;
	}
	
	public void changeBallSpeed(float speedModifier)
	{
		speed = speed + speedModifier;
		rigidbody.velocity = calculateVelocity(speed, currentAngle);
	}
	
	private float calculateDirection(float velocityInX, float velocityInY)
	{
		float angle = Mathf.Rad2Deg * Mathf.Atan(velocityInY / velocityInX);
		if(velocityInY > 0 && velocityInX < 0)
		{
			//quadrant 2: angle 90 through 180
			angle = 180 + angle;
		}
		else if(velocityInY < 0 && velocityInX < 0)
		{
			//quadrant 3: angle -90 through -180
			angle = -(180 - angle);
		}
		else if(velocityInY < 0 && velocityInX > 0)
		{
			//quadrant 4: angle 0 through -90
		}
		else
		{
			//quadrant 1: angle 0 through 90
		}	
		
		return angle;
	}
	
	private Vector3 calculateVelocity(float speed, float angle)
	{
		float speedInX = Mathf.Cos(Mathf.Deg2Rad * angle) * speed;
		float speedInY = Mathf.Sin(Mathf.Deg2Rad * angle) * speed;
		
		//when the ball speeds up, increase the length of the trail behind it
		TrailRenderer t = (TrailRenderer)(GetComponent(typeof(TrailRenderer)));
		t.time = Mathf.Min((speed / 20) - 0.5f, 5.0f);
		
		return new Vector3(speedInX, speedInY, 0);	
	}
}
