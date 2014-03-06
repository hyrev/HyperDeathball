using UnityEngine;
using System.Collections;

public class OptionsContainer : MonoBehaviour {
	//Options menu values
	public float volumeValue = 0.5f;

	//Powerups menu values
	public bool speedUpToggle = true;
	public bool shrinkBallToggle = true;
	public bool growShieldToggle = true;
	
	public float speedUpValue = 1f;
	public float shrinkBallValue = 1f;
	public float growShieldValue = 1f;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
