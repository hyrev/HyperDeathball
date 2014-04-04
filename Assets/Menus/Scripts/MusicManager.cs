using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	//Included to make sure we don't double up the options container
	public static MusicManager Instance;

	// Use this for initialization
	void Start () {
		if(Instance) {
			DestroyImmediate(gameObject);
		} else {
			DontDestroyOnLoad(this);
			Instance = this;
		}
	}
}
