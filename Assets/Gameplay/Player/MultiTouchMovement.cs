using UnityEngine;
using System.Collections;

public class MultiTouchMovement : MonoBehaviour {

	public GameObject player;		//Paddle Object
	public GameObject otherInput;	//Other input point
	public float leftMovementMax;	//Furthest the left the paddle can move
	public float rightMovementMax;	//Furthest the right the paddle can move
	public float snapHeight;

	private int touchNum;					//Which finger is currently touching this input
	private bool isPaused;

	void Start () {
		touchNum = 0;
	}

	void Update () {
		isPaused = Camera.main.GetComponent<PauseMenu>().isPaused;
		if(!isPaused){
			if (Input.GetMouseButton(0)) {

				//Check to see if we're actually hitting this touch point with our input
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast(ray, out hit)) {
					if(hit.collider.name == name) {
						if(otherInput.GetComponent <MultiTouchMovement>().touchNum == 1){
							touchNum = 2;
						} else {
							touchNum = 1;
						}
					}
				}

				//If we have hit the input, calculate where the paddle should be
				if(touchNum != 0){
					Vector3 curScreenPoint = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.transform.position.z * -1);
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
			} else if(Input.GetMouseButtonUp(0)) {
				touchNum = 0;
				SnapBack ();
			}
		}
	}

	void SnapBack() {
		transform.localPosition = new Vector3(0,snapHeight, 0);
	}
}
