using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	[SerializeField] private CharacterController characterController;
	[SerializeField] private GameObject hudObject;

	[SerializeField] private float speedMoving = 10.0f;
	[SerializeField] private float jumpHeight = 10.0f;
	[SerializeField] private float speedRunning = 15.0f;

	[SerializeField] private float mouseSensitivity = 3.0f;
	[SerializeField] private float mouseLimit = 90.0f;

	private Hud hud;
	private float currentJumpHeight = 0f;
	private float currentHealth = 0.0f;
	private float mouseY = 0f;

	void Start () {
		characterController = GetComponent<CharacterController>();
		hud = hudObject.GetComponent<Hud>();
	}
	
	void Update () {
		if (isAlive ()) {
			keyboardMovement ();
			mouseMovement ();
		} else {  
			StartCoroutine (PlayerDies());
		}
	}

	bool isAlive(){
		Health health = gameObject.GetComponent<Health> ();
		DisplayCurrentHealth(health);

		if (health != null) {
			return health.isAlive();
		}

		return true;
	}

	private void DisplayCurrentHealth(Health health){
		float healthValue = health.GetCurrentHealth();
		if (currentHealth != healthValue){
			currentHealth = healthValue;
			hud.SetHealthPercentage(healthValue / 10);
		}
	}

	private IEnumerator PlayerDies(){
		Camera.main.transform.localRotation = Quaternion.Euler (90, 90, 0);
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene("newmenu");
	}

	private void keyboardMovement(){
		float verticalMovement = Input.GetAxis ("Vertical") * speedMoving;
		float horizontalMovement = Input.GetAxis ("Horizontal") * speedMoving;

		if (characterController.isGrounded && Input.GetButton ("Jump")){
			currentJumpHeight = jumpHeight;
		} else if (!characterController.isGrounded){
			currentJumpHeight += Physics.gravity.y * Time.deltaTime;
		}
		
		// ugly hack for super jumping :D
		if (Input.GetKeyDown ("k")){
			currentJumpHeight = 50.0f;
		}

		if (Input.GetKeyDown ("left shift")){
			speedMoving += speedRunning;
		}
		else if (Input.GetKeyUp ("left shift")){
			speedMoving -= speedRunning;
		}

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

}
