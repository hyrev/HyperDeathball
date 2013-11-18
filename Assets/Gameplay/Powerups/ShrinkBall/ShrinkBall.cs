using UnityEngine;
using System.Collections;

public class ShrinkBall : BasePowerup {

	// Use this for initialization
	void Start () {
	
	}
	
	public override void activate (GameObject ball)
	{
		//base.activate (ball);
		Debug.Log("Shrink activated" );
	}
}
