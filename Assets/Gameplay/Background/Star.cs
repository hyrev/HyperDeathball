using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour
{
	public float minScrollSpeed;		//min and max scrolling speed
	public float maxScrollSpeed;
	public float minStarScale;			//min and max scale
	public float maxStarScale;

	private float scrollSpeed;			//actual scroll speed
	private float starScale;			//actual scale


	void Start()
	{
		//init the star with random values from within the range
		regenerateSpeedAndSize();
		transform.localScale = new Vector3(starScale, starScale, starScale);
	}
	
	void Update()
	{
		//move the star across the screen
		transform.position = new Vector3(transform.position.x + scrollSpeed, transform.position.y, transform.position.z);
	}
	
	public void regenerateSpeedAndSize()
	{
		scrollSpeed = Random.Range(minScrollSpeed, maxScrollSpeed);
		starScale = Random.Range(minStarScale, maxStarScale);
	}
}
