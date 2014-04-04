using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour
{
	public int gridWidth;			//how many cubes are in a row
	public int gridHeight;			//how many cubes are in a column
	public float cubeXOffset;		//how much space to leave between columns
	public float cubeYOffset;		//how much space to leave between rows
	
	public GameObject[,] grid;		//xy grid of cubes, each with adjacencies

	public AudioClip pulseSound;
	
	public enum Direction {up, down, left, right};
	private int segmentLength = 5;
	
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

	}
	
	//given a grid point, pulse outward in all directions
	public void gridPulseFromLocation(int posX, int posY)
	{
		grid[posX, posY].GetComponent<GridCube>().pulse();
		audio.PlayOneShot(pulseSound);
	}
	
	//given a player and a score, set which grid points are active
	public void setScoreForPlayer(int score, int player)
	{
		Vector2 origin = new Vector2(12, 12);
		if(player == 2)
		{
			origin.x = 42;
		}
		
		for(int x = (int)origin.x; x < origin.x + (segmentLength + 2) * 2 + 3; x++)
		{
			for(int y = (int)origin.y; y < origin.y + segmentLength * 2 + 2; y++)
			{
				grid[x, y].GetComponent<GridCube>().deactivate();
			}
		}
		
		int tensPosition = score / 10;
		determineCharacterToDraw(origin, tensPosition);
		
		origin.x = origin.x + segmentLength + 5;
		int onesPosition = score % 10;
		determineCharacterToDraw(origin, onesPosition);
	}
	
	private void determineCharacterToDraw(Vector2 origin, int digit)
	{
		switch(digit)
		{
		case 0:
			drawZero(origin);
			break;
		case 1:
			drawOne(origin);
			break;
		case 2:
			drawTwo(origin);
			break;
		case 3:
			drawThree(origin);
			break;
		case 4:
			drawFour(origin);
			break;
		case 5:
			drawFive(origin);
			break;
		case 6:
			drawSix(origin);
			break;
		case 7:
			drawSeven(origin);
			break;
		case 8:
			drawEight(origin);
			break;
		case 9:
			drawNine(origin);
			break;
		default:
			break;
		}
	}
	
	private void activateGridLine(Vector2 origin, Direction direction, int length)
	{
		for(int x = 0; x <= length; x++)
		{
			int posX = (int)origin.x;
			int posY = (int)origin.y;
			if(direction == Direction.right)
			{
				posX = posX + x;
				//grid[posX, posY + 1].GetComponent<GridCube>().activate();
			}
			else if(direction == Direction.down)
			{
				posY = posY + x;
				//grid[posX - 1, posY].GetComponent<GridCube>().activate();
			}
			else if(direction == Direction.left)
			{
				posX = posX - x;
				//grid[posX, posY - 1].GetComponent<GridCube>().activate();
			}
			else
			{
				posY = posY - x;
				//grid[posX + 1, posY].GetComponent<GridCube>().activate();
			}
			
			grid[posX, posY].GetComponent<GridCube>().activate();
		}
	}
	
	private void drawZero(Vector2 origin)
	{
		activateGridLine(origin, Direction.right, segmentLength);
		activateGridLine(origin, Direction.down, segmentLength * 2);
		activateGridLine(new Vector2(origin.x + segmentLength, origin.y + (segmentLength * 2)), Direction.up, segmentLength * 2);
		activateGridLine(new Vector2(origin.x + segmentLength, origin.y + (segmentLength * 2)), Direction.left, segmentLength);
	}
	
	private void drawOne(Vector2 origin)
	{
		activateGridLine(new Vector2(origin.x + segmentLength, origin.y), Direction.down, segmentLength * 2);
	}
	
	private void drawTwo(Vector2 origin)
	{
		activateGridLine(origin, Direction.right, segmentLength);
		activateGridLine(new Vector2(origin.x + segmentLength, origin.y), Direction.down, segmentLength);
		activateGridLine(new Vector2(origin.x, origin.y + segmentLength), Direction.right, segmentLength);
		activateGridLine(new Vector2(origin.x, origin.y + segmentLength), Direction.down, segmentLength);
		activateGridLine(new Vector2(origin.x, origin.y + (segmentLength * 2)), Direction.right, segmentLength);
	}
	
	private void drawThree(Vector2 origin)
	{
		activateGridLine(new Vector2(origin.x + segmentLength, origin.y), Direction.down, segmentLength * 2);
		activateGridLine(new Vector2(origin.x + segmentLength, origin.y), Direction.left, segmentLength);
		activateGridLine(new Vector2(origin.x + segmentLength, origin.y + segmentLength), Direction.left, segmentLength);
		activateGridLine(new Vector2(origin.x + segmentLength, origin.y + (segmentLength * 2)), Direction.left, segmentLength);
	}
	
	private void drawFour(Vector2 origin)
	{
		activateGridLine(origin, Direction.down, segmentLength);
		activateGridLine(new Vector2(origin.x + segmentLength, origin.y), Direction.down, segmentLength * 2);
		activateGridLine(new Vector2(origin.x + segmentLength, origin.y + segmentLength), Direction.left, segmentLength);
	}
	
	private void drawFive(Vector2 origin)
	{
		activateGridLine(origin, Direction.right, segmentLength);
		activateGridLine(origin, Direction.down, segmentLength);
		activateGridLine(new Vector2(origin.x, origin.y + segmentLength), Direction.right, segmentLength);
		activateGridLine(new Vector2(origin.x + segmentLength, origin.y + segmentLength), Direction.down, segmentLength);
		activateGridLine(new Vector2(origin.x, origin.y + (segmentLength * 2)), Direction.right, segmentLength);
	}
	
	private void drawSix(Vector2 origin)
	{
		activateGridLine(origin, Direction.right, segmentLength);
		activateGridLine(origin, Direction.down, segmentLength * 2);
		activateGridLine(new Vector2(origin.x, origin.y + segmentLength), Direction.right, segmentLength);
		activateGridLine(new Vector2(origin.x + segmentLength, origin.y + segmentLength), Direction.down, segmentLength);
		activateGridLine(new Vector2(origin.x, origin.y + (segmentLength * 2)), Direction.right, segmentLength);
	}
	
	private void drawSeven(Vector2 origin)
	{
		activateGridLine(origin, Direction.right, segmentLength);
		activateGridLine(new Vector2(origin.x + segmentLength, origin.y), Direction.down, segmentLength * 2);
	}
	
	private void drawEight(Vector2 origin)
	{
		activateGridLine(origin, Direction.right, segmentLength);
		activateGridLine(origin, Direction.down, segmentLength * 2);
		activateGridLine(new Vector2(origin.x, origin.y + segmentLength), Direction.right, segmentLength);
		activateGridLine(new Vector2(origin.x + segmentLength, origin.y), Direction.down, segmentLength * 2);
		activateGridLine(new Vector2(origin.x, origin.y + (segmentLength * 2)), Direction.right, segmentLength);
	}
	
	private void drawNine(Vector2 origin)
	{
		activateGridLine(origin, Direction.right, segmentLength);
		activateGridLine(origin, Direction.down, segmentLength);
		activateGridLine(new Vector2(origin.x, origin.y + segmentLength), Direction.right, segmentLength);
		activateGridLine(new Vector2(origin.x + segmentLength, origin.y), Direction.down, segmentLength * 2);
	}
}
