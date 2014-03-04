﻿using UnityEngine;
using System.Collections;

public class GrowShield : BasePowerup {

	public static Vector3 originalSize;
	public Vector3 sizeModifier;

	private static bool childActivated;
	private static GameObject shield;

	new void Start () {

		base.Start ();

		sizeModifier = new Vector3(0.5f,0.5f,5f);
		originalSize = new Vector3(0.5f,0.5f,2.5f);
	
	}
	
	new void Update () {

		base.Update ();

		if(removePowerup){
			
			shield.transform.localScale = originalSize;
			
			PowerupManager.setPowerupOnScreen(false);

			Destroy(gameObject);
			
			removePowerup = false;

			childActivated = false;
			
		}
	
	}

	public override void activate()
	{
		if (!childActivated) {

			//Debug.Log("-GrowShield- Powerup!");
			shield = GameObject.Find("Player1");

			shield.transform.localScale = sizeModifier;

			activated = true;
			childActivated = true;

		}
	}
}
