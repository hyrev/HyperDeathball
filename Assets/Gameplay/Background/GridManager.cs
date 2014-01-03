using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour
{
	public int gridWidth;			//how many cubes are in a row
	public int gridHeight;			//how many cubes are in a column
	public float cubeXOffset;		//how much space to leave between columns
	public float cubeYOffset;		//how much space to leave between rows
	
	public GameObject[,] grid;		//xy grid of cubes, each with adjacencies
	
	private bool test;				//TEST VARIABLE! need to remove all instances of this and its associated code eventually!

	void Start()
	{
		//TEST CODE!
	 	test = false;
	 	
		//initialize grid and create GridCubes
		grid = new GameObject[gridWidth, gridHeight];
		for(int x = 0; x < gridWidth; x++)
		{
			for(int y = 0; y < gridHeight; y++)
			{
				//create the objects and place them accordingly
				grid[x, y] = (GameObject)Instantiate(Resources.Load("prefab_GridCube"));
				grid[x, y].transform.localPosition = new Vector3(transform.position.x + (x * cubeXOffset), transform.position.y - (y * cubeYOffset), transform.position.z);
				
				//determine the GridCubes adjacencies
				if(x != 0)
				{
					grid[x, y].GetComponent<GridCube>().leftNeighbour = grid[x-1, y].GetComponent<GridCube>();
					grid[x-1, y].GetComponent<GridCube>().rightNeighbour = grid[x, y].GetComponent<GridCube>();
				}
				
				if(y != 0)
				{
					grid[x, y].GetComponent<GridCube>().topNeighbour = grid[x, y-1].GetComponent<GridCube>();
					grid[x, y-1].GetComponent<GridCube>().bottomNeighbour = grid[x, y].GetComponent<GridCube>();
				}
			}
		}
	}
	
	void Update()
	{
		//TEST CODE!
		if(!test)
		{
			gridPulseFromLocation(gridWidth / 2, gridHeight / 2);
			test = true;
		}
	}
	
	//given a grid point, pulse outward in all directions
	public void gridPulseFromLocation(int posX, int posY)
	{
		grid[posX, posY].GetComponent<GridCube>().pulse();
	}
}
