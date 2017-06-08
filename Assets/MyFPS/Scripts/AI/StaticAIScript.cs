using UnityEngine;
using System.Collections;

public class StaticAIScript : MonoBehaviour {

	public float enemySpeed = 5.0f;
	public float enemyRange = 30.0f;

	private CharacterController characterControler;
	private Transform player;
	private Transform myObject;
	private float minDistanceFromPlayer = 5.0f;
	private EnemyAttack attack;
	private bool isRidgidBody = false;

	
	// Use this for initialization
	void Start () {
		characterControler = GetComponent<CharacterController> ();
		myObject = transform;
		GameObject go = GameObject.FindWithTag ("Player");
		player = go.transform;
		attack = gameObject.GetComponent<EnemyAttack> ();
	}
	
	// Update is called once per frame
	void Update (){

		float distanceFromPlayer = Vector3.Distance (myObject.position, player.position);

		//Jeżeli dystans jaki dzieli obiekt wroga od obiektu gracza mieści się w zakresie widzenia wroga to 
		if (distanceFromPlayer < enemyRange && distanceFromPlayer > minDistanceFromPlayer && isAlive()) {

			Vector3 playerPosition = new Vector3(player.position.x, player.position.y, player.position.z);

			//Funkcja Quaternion.Slerp (spherical linear interpolation) pozwala obracać obiekt w zadanym kierunku z zadaną prędkością.
			myObject.rotation = Quaternion.Slerp (myObject.rotation, Quaternion.LookRotation (playerPosition - myObject.position), enemySpeed * Time.deltaTime);

			attack.doAttack ();
		}

		if (!isAlive()) {
			if (!isRidgidBody) {
				gameObject.AddComponent<Rigidbody> ();
				isRidgidBody = true;
			}
			GetComponent<Rigidbody> ().freezeRotation = false;
		}
	}

	bool isAlive(){
		Health health = gameObject.GetComponent<Health> ();

		if (health != null) {
			return health.isAlive();
		}

		return true;
	}
}
