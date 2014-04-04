using UnityEngine;
using System.Collections;

public class OptionsContainer : MonoBehaviour {
	//Included to make sure we don't double up the options container
	public static OptionsContainer Instance;

	//Options menu values
	public float volumeValue = 0.5f;

	//Powerups menu values
	public bool[] toggles;
	public float[] values;

	void Awake() {
		if(Instance) {
			DestroyImmediate(gameObject);
		} else {
			DontDestroyOnLoad(this);
			Instance = this;
		}
	}

	void Update () {
		AudioListener.volume = volumeValue;
	}
}
