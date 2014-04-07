﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ball : MonoBehaviour
{
	//Default values set in inspector
	public float speed;
	public float bounceIncrement;
	public int leftScorePosition;
	public int rightScorePosition;
	TrailRenderer trail;
	public float trailLimit;
	private List<string> powerUps = new List<string>();
	
	//Angle stored as DEGREES, convert to radians when necessary
	private float currentAngle;
	
	private GameObject lastCollidedPlayer;
	private float currentSpeed;
	private bool colliding;

	void Start()
	{
		
		trail = (TrailRenderer)(GetComponent(typeof(TrailRenderer)));
		trailLimit =  0.6f;
		
		//Initialize the velocity of the ball based on the preset speed and a randomly generated angle
		currentAngle = Random.Range(150, 210);
		currentSpeed = 0;
		rigidbody.velocity = calculateVelocity(currentSpeed, currentAngle);
		
		colliding = false;
	}

	void FixedUpdate()
	{
		//ball has entered left player's net
		if(transform.position.x < leftScorePosition)
		{
			currentSpeed = 0;
			currentAngle = Random.Range(-30, 30);
			transform.position = new Vector3(0, 0, 0);
			rigidbody.velocity = calculateVelocity(currentSpeed, currentAngle);
			
			//pulse from left side
			GridManager grid = GameObject.Find("GridManager").GetComponent<GridManager>();
			grid.gridPulseFromLocation(0, grid.gridHeight / 2);
			
			//increment player 2's score
			ScoreManager score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
			score.player2Scores();
			
			//reset the computer's destination if there is one
			ComputerPlayer comp = GameObject.Find("Player2").GetComponent<ComputerPlayer>();
			if(comp != null)
			{
				comp.resetDestination();
			}
		}
		
		//ball has entered right player's net
		if(transform.position.x > rightScorePosition)
		{
			currentSpeed = 0;
			currentAngle = Random.Range(150, 210);
			transform.position = new Vector3(0, 0, 0);
			rigidbody.velocity = calculateVelocity(currentSpeed, currentAngle);
			
			//pulse from right side
			GridManager grid = GameObject.Find("GridManager").GetComponent<GridManager>();
			grid.gridPulseFromLocation(grid.gridWidth - 1, grid.gridHeight / 2);
			
			//increment player 1's score
			ScoreManager score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
			score.player1Scores();
			
			//reset the computer's destination if there is one
			ComputerPlayer comp = GameObject.Find("Player2").GetComponent<ComputerPlayer>();
			if(comp != null)
			{
				comp.resetDestination();
			}
		}
		
		//gradually accumulate speed every time the ball respawns
		if(currentSpeed < speed && !colliding)
		{
			currentSpeed = currentSpeed + 0.01f;
			rigidbody.velocity = calculateVelocity(currentSpeed, currentAngle);
		}
	}
	
	void OnCollisionEnter(Collision c)
	{
		//keep track of the last person to hit the ball (for powerups etc)
		if(c.gameObject.name.CompareTo("Player1") == 0 || c.gameObject.name.CompareTo("Player2") == 0)
		{
			lastCollidedPlayer = c.gameObject;
		}
		
		colliding = true;
	}
	
	void OnCollisionExit(Collision c)
	{
		//after colliding, recalculate the direction the ball is going
		currentAngle = calculateDirection(rigidbody.velocity.x, rigidbody.velocity.y);

		//increase ball speed
		changeSpeed(bounceIncrement);
		
		//if the player hit the ball, have the computer go find it
		if(c.gameObject.name.CompareTo("Player1") == 0)
		{
			ComputerPlayer comp = GameObject.Find("Player2").GetComponent<ComputerPlayer>();
			if(comp != null)
			{
				comp.recalculateDestination();
			}
		}
		
		//if the computer hit the ball, reset its destination
		if(c.gameObject.name.CompareTo("Player2") == 0)
		{
			ComputerPlayer comp = GameObject.Find("Player2").GetComponent<ComputerPlayer>();
			if(comp != null)
			{
				comp.resetDestination();
			}
		}
		
		colliding = false;
	}

	public void addPowerUp(string p){

		powerUps.Add(p);

		//Debug.Log("Added " + p + " to ball " + transform.name + ": " + powerUps.Count);

	}

	public bool containsPowerUp(string p){
		return powerUps.Contains(p);
	}

	public void removePowerUp(string p){

		powerUps.Remove(p);

		//Debug.Log("Removed " + p + " from ball " + transform.name + ": " + powerUps.Count);

	}
	
	//do not access the lastPlayer directly, use this
	public GameObject getLastPlayer()
	{
		return lastCollidedPlayer;
	}
	
	public void changeSpeed(float speedModifier)
	{
		speed = speed + speedModifier;
	}
	
	public void changeSize(Vector3 sizeModifier)
	{
		transform.localScale = sizeModifier;
		trail.startWidth = sizeModifier.x;
	}
	
	//Changes only the color for now
	public void changeMaterial(Color color)
	{
		if(powerUps.Count == 0 || color != Color.white){
			renderer.material.color = color;
		}
	}

	public void addCurrentSpeed(GameObject ball){

		ball.GetComponent<Ball>().speed = currentSpeed;

	}
	
	public float getDirection()
	{
		return currentAngle;
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
		//TrailRenderer t = (TrailRenderer)(GetComponent(typeof(TrailRenderer)));
		trail.time = Mathf.Min((speed / 20) - 0.5f, 5.0f);
		if(trail.time > trailLimit) trail.time = trailLimit;
		
		return new Vector3(speedInX, speedInY, 0);	
	}
}
