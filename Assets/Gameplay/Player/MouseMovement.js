#pragma strict
var sensitivityY = 1.0;

function Start () {

}

function Update () {
	transform.position.y += Input.GetAxis("Mouse Y") * sensitivityY;
}