using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	//these all have default values in the inspector
	public int speed;
	public int topBounds;
	public int bottomBounds;
	
	void Start()
	{
	
	}
	
	void Update()
	{
		//handle input for moving UP and prevent the player from leaving the screen
		if(Input.GetButton("UP"))
		{
			transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
			if(transform.position.y > topBounds)
			{
				//temp vector used because C# is picky about modifying single components of properties
				Vector3 temp = new Vector3(transform.position.x, topBounds, transform.position.z);
				transform.position = temp;	
			}
		}
		
		//handle input for moving DOWN and prevent the player from leaving the screen
		if(Input.GetButton("DOWN"))
		{
			transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
			if(transform.position.y < bottomBounds)
			{
				//temp vector used because C# is picky about modifying single components of properties
				Vector3 temp = new Vector3(transform.position.x, bottomBounds, transform.position.z);
				transform.position = temp;	
			}
		}
	}
}
