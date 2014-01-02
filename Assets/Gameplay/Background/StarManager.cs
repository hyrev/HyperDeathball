using UnityEngine;
using System.Collections;

public class StarManager : MonoBehaviour
{
	public int numberOfStars;		//how many star objects are kept on the screen at one time
	public int refreshDistance;		//how far fro the manager a star can be before being refreshed
	public int bgHeight;			//height of the starry area
	
	private GameObject[] stars;

	void Start()
	{
		//init stars
		//give them random starting positions across the game area so it doesnt look awful at launch
		stars = new GameObject[numberOfStars];
		for(int x = 0; x < numberOfStars; x++)
		{
			stars[x] = (GameObject)Instantiate(Resources.Load("prefab_Star"));
			stars[x].transform.position = new Vector3(transform.position.x + Random.Range(1, refreshDistance), transform.position.y - Random.Range(1, bgHeight), transform.position.z);
		}
	}
	
	void Update()
	{
		//check to see if any stars need to be reloaded, and reload them if they do
		for(int x = 0; x < numberOfStars; x++)
		{
			if(stars[x].transform.position.x - transform.position.x > refreshDistance)
			{
				stars[x].GetComponent<Star>().regenerateSpeedAndSize();
				stars[x].transform.position = new Vector3(transform.position.x, transform.position.y - Random.Range(1, bgHeight), transform.position.z);
			}
		}
	}
}
