#pragma strict
var sensitivityY = 1.0;

function Update () {
	transform.position.y += Input.GetAxis("Mouse Y") * sensitivityY;
}