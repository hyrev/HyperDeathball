using UnityEngine;
using System.Collections;

public class GridCube : MonoBehaviour
{
	public float pulseScale;			//maximum size to scale to when pulsing
	public float pulseIncrement;		//step value for the increase/decrease in scale

	public GridCube topNeighbour;		//adjacent GridCubes
	public GridCube bottomNeighbour;
	public GridCube leftNeighbour;
	public GridCube rightNeighbour;
	
	public enum PulseStatus {idle, grow, shrink};
	public PulseStatus currentStatus;
	
	private Vector3 initialScale;

	void Start()
	{
		//init as idle and set the base scale
		currentStatus = PulseStatus.idle;
		initialScale = transform.localScale;
	}
	
	void Update()
	{
		if(currentStatus == PulseStatus.grow)
		{
			//scale the cube up
			transform.localScale = new Vector3(transform.localScale.x + pulseIncrement, transform.localScale.y + pulseIncrement, transform.localScale.z + pulseIncrement);
			
			//if the current scale is partway to the maximum scale, start scaling its neighbours
			//only pulse neighbours that are idle!
			if(transform.localScale.x > ((pulseScale - initialScale.x) / 1.25f))
			{
				if(topNeighbour && topNeighbour.currentStatus == PulseStatus.idle)
				{
					topNeighbour.pulse();
				}
				if(bottomNeighbour && bottomNeighbour.currentStatus == PulseStatus.idle)
				{
					bottomNeighbour.pulse();
				}
				if(leftNeighbour && leftNeighbour.currentStatus == PulseStatus.idle)
				{
					leftNeighbour.pulse();
				}
				if(rightNeighbour && rightNeighbour.currentStatus == PulseStatus.idle)
				{
					rightNeighbour.pulse();
				}
			}
			
			//once you hit the max scale, set the GridCube to shrink
			if(transform.localScale.x > pulseScale)
			{
				currentStatus = PulseStatus.shrink;
			}
		}
		else if(currentStatus == PulseStatus.shrink)
		{
			//shrink if the GridCube is still bigger than it started, otherwise set it to idle
			if(transform.localScale.x > initialScale.x)
			{
				transform.localScale = new Vector3(transform.localScale.x - pulseIncrement, transform.localScale.y - pulseIncrement, transform.localScale.z - pulseIncrement);
			}
			else
			{
				currentStatus = PulseStatus.idle;
			}
		}
	}
	
	public void pulse()
	{
		currentStatus = PulseStatus.grow;
	}
}
