using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed = 10;
	public float jump = 5;
	public Text winText;

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
	private bool isGrounded = false;

	Camera cam;
	private void Awake()
	{
		cam = FindObjectOfType<Camera>();
	}

	// At the start of the game..
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the text property of our Win Text UI to an empty string, making the 'You Win' (game over message) blank
		winText.text = "";
	}

	void OnCollisionStay()
	{
		isGrounded = true;
	}

	// Each physics step..
	void FixedUpdate ()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Quaternion rot = Quaternion.FromToRotation(Vector3.forward, Vector3.ProjectOnPlane(cam.transform.forward, Vector3.up).normalized);
		movement = rot * movement;

		// Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
		// multiplying it by 'speed' - our public player speed that appears in the inspector
		rb.AddForce (movement * speed);

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
			isGrounded = false;
		}
	}

	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("Victory"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear
			other.gameObject.SetActive(false);

			winText.text = "You Win!";
		}
	}
}