using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public CharacterController characterController;
	public float speedMoving = 10.0f;
	public float jumpHeight = 10.0f;
	public float currentJumpHeight = 0f;
	public float speedRunning = 15.0f;

	public float mouseSensitivity = 3.0f;
	public float mouseLimit = 90.0f;
	public float mouseY = 0f;


	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (isAlive ()) {
			keyboardMovement ();
			mouseMovement ();
		} else {  
			StartCoroutine (PlayerDies());
		}
	
	}

	private IEnumerator PlayerDies(){
		Camera.main.transform.localRotation = Quaternion.Euler (90, 90, 0);
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene("menu");
	}

	private void keyboardMovement(){
		float verticalMovement = Input.GetAxis ("Vertical") * speedMoving;
		float horizontalMovement = Input.GetAxis ("Horizontal") * speedMoving;

		if (characterController.isGrounded && Input.GetButton ("Jump"))
			currentJumpHeight = jumpHeight;
		else if (!characterController.isGrounded)
			currentJumpHeight += Physics.gravity.y * Time.deltaTime;

		if (Input.GetKeyDown ("left shift"))
			speedMoving += speedRunning;
		else if (Input.GetKeyUp ("left shift"))
			speedMoving -= speedRunning;

		Vector3 movement = new Vector3 (horizontalMovement, currentJumpHeight, verticalMovement);
		movement = transform.rotation * movement;

		characterController.Move (movement * Time.deltaTime);
	}

	private void mouseMovement(){
		float mouseX = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, mouseX, 0);
		mouseY -= Input.GetAxis ("Mouse Y") * mouseSensitivity;

		mouseY = Mathf.Clamp (mouseY, -mouseLimit, mouseLimit);
		Camera.main.transform.localRotation = Quaternion.Euler (mouseY, 0, 0);

	}

	bool isAlive(){
		Health health = gameObject.GetComponent<Health> ();

		if (health != null) {
			return health.isAlive();
		}

		return true;
	}
}
