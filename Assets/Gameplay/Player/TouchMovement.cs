using UnityEngine;
using System.Collections;

public class TouchMovement : MonoBehaviour {
	public Transform paddle;
	private bool touching;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!Camera.main.GetComponent<PauseMenu>().isPaused){
			if(Input.GetMouseButton(0)){
				RaycastHit hit = new RaycastHit();
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray,out hit, 100)){
					if(hit.transform == paddle){
						touching = true;
					}
				}
			}
			else{
				touching = false;
			}

			if(touching){
				Vector3 curScreenPoint = new Vector3(paddle.position.x,Input.mousePosition.y,Camera.main.transform.position.z*-1);
				Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
				transform.position = new Vector3(paddle.position.x,curPosition.y,0);

				if(Input.GetAxis("Mouse X")<-0.2){
					//Code for action on mouse moving left
					transform.Rotate(new Vector3(0,Input.GetAxis("Mouse X")*10,0));
					//print("Mouse moved left");
				}
				if(Input.GetAxis("Mouse X")>0.2){
					//Code for action on mouse moving right
					transform.Rotate(new Vector3(0,Input.GetAxis("Mouse X")*10,0));
					//print("Mouse moved right");
				}
			}
		}
	}
}
