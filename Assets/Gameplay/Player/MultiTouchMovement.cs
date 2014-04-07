using UnityEngine;
using System.Collections;

public class MultiTouchMovement : MonoBehaviour {

	public GameObject player;		//Paddle Object
	public GameObject otherInput;	//Other input point
	public float leftMovementMax;	//Furthest the left the paddle can move
	public float rightMovementMax;	//Furthest the right the paddle can move
	public float snapHeight;

	private bool isPaused;
	private bool isTouching;

	void Start () {

	}

	void Update () {
		isPaused = Camera.main.GetComponent<PauseMenu>().isPaused;
		if(!isPaused){
			isTouching = false;
			foreach(Touch touch in Input.touches) {
				if(touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
					//Check to see if we're actually hitting this touch point with our input
					Ray ray = Camera.main.ScreenPointToRay(touch.position);
					RaycastHit hit;
					
					if (Physics.Raycast(ray, out hit)) {
						if(hit.collider.name == name) {
							isTouching = true;

							Vector3 curScreenPoint = new Vector3(touch.position.x,touch.position.y,Camera.main.transform.position.z * -1);
							curScreenPoint = Camera.main.ScreenToWorldPoint(curScreenPoint);
							curScreenPoint.z = 0;
							transform.position = curScreenPoint;
							Vector3 newPos = (transform.position + otherInput.transform.position) / 2.0f;

							if(newPos.x < rightMovementMax && newPos.x > leftMovementMax) {
								Vector3 lookPos =  (Vector3.Cross (transform.position-newPos, Vector3.forward)).normalized;
								lookPos.z = 0;
								player.transform.rotation = Quaternion.LookRotation(lookPos);
								player.transform.position = newPos;
							}
						}
					}
				}
			}
			if(!isTouching) {
				SnapBack ();
			}
		}
	}

	void SnapBack() {
		transform.localPosition = new Vector3(0,snapHeight, 0);
	}
}
