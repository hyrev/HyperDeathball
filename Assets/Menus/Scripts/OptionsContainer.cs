using UnityEngine;
using System.Collections;

public class OptionsContainer : MonoBehaviour {
	//Options menu values
	public float volumeValue = 0.5f;

	//Powerups menu values
	public bool[] toggles;
	public float[] values;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
