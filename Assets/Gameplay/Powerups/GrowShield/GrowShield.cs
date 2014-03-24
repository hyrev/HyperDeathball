using UnityEngine;
using System.Collections;

public class GrowShield : BasePowerup {

	public static Vector3 originalSize;
	public Vector3 sizeModifier;

	private static bool childActivated;
	private static GameObject shield;

	new void Start () {

		base.Start ();
		
		float optionsModifier = GameObject.Find ("OptionsContainer").GetComponent<OptionsContainer>().values[2];
		sizeModifier = new Vector3(0.5f,0.5f,optionsModifier*5f);
		originalSize = new Vector3(0.5f,0.5f,2.5f);
	
	}
	
	new void Update () {

		base.Update ();

		if(removePowerup){
			
			shield.transform.localScale = originalSize;
			
			PowerupManager.setPowerupOnScreen(false);

			removePowerup = false;

			childActivated = false;

			Destroy(gameObject);
			
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
