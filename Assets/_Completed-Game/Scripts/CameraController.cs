using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// store a public reference to the Player game object, so we can refer to it's Transform
	public GameObject player;

	// Store a Vector3 offset from the player (a distance to place the camera from the player at all times)
	private Vector3 offset;

	private float camRotSpeed = 3;

	// At the start of the game..
	void Start ()
	{
		// Create an offset by subtracting the Camera's position from the player's position
		offset = transform.position - player.transform.position;
	}

	Vector3 targetPos;
	Vector3 currentPos;
	void LateUpdate ()
	{
		// Set the position of the Camera (the game object this script is attached to)
		// to the player's position, plus the offset amount
		
	}

    private void Update()
    {
		targetPos = Vector3.Lerp(currentPos, player.transform.position, Time.deltaTime * 5);

		if (Input.GetButton("Fire2"))
		{
			offset = Quaternion.Euler(Input.GetAxis("Mouse Y") * -1 * camRotSpeed, Input.GetAxis("Mouse X") * camRotSpeed, 0) * offset;
		}
		if (Input.GetJoystickNames().Length > 0)
        {
			offset = Quaternion.Euler(Input.GetAxis("RightStickVertical") * -1 * camRotSpeed, Input.GetAxis("RightStickHorizontal") * camRotSpeed, 0) * offset;
		}

		offset.Scale(Vector3.one * (1-Input.GetAxis("Mouse ScrollWheel")));
        

		currentPos = targetPos;
		transform.position = targetPos + offset;
		transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up);
    }
}