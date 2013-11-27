#pragma strict
var paddle : Transform;

function Update () {
	if(Input.GetMouseButton(0)){
		var curScreenPoint = Vector3(paddle.position.x,Input.mousePosition.y,Camera.main.transform.position.z*-1);
		var curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
	    transform.position = Vector3(paddle.position.x,curPosition.y,0);
	}
}