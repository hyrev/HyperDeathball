using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour
{
	public int gridWidth;			//how many cubes are in a row
	public int gridHeight;			//how many cubes are in a column
	public float cubeXOffset;		//how much space to leave between columns
	public float cubeYOffset;		//how much space to leave between rows
	
	public GameObject[,] grid;		//xy grid of cubes, each with adjacencies

	void Start()
	{
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
				}
				
				/*
				if(x != (gridWidth - 1))
				{
					grid[x, y].GetComponent<GridCube>().rightNeighbour = grid[x+1, y].GetComponent<GridCube>();
				}
				*/
				
				if(y != 0)
				{
					grid[x, y].GetComponent<GridCube>().topNeighbour = grid[x, y-1].GetComponent<GridCube>();
				}
				
				/*
				if(y != (gridHeight - 1))
				{
					grid[x, y].GetComponent<GridCube>().bottomNeighbour = grid[x, y+1].GetComponent<GridCube>();
				}
				*/
			}
		}
	}
	
	void Update()
	{
	
	}
}
