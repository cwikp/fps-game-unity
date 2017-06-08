﻿using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour {

	public float enemySpeed = 15.0f;
	public float enemyRange = 30.0f;

	private CharacterController characterControler;
	private Transform player;
	private Transform myObject;
	private float minDistanceFromPlayer = 5.0f;
	private bool isRidgidBody = false;

	public AudioSource audioSource;
	public AudioClip audioClip;
	
	// Use this for initialization
	void Start () {
		characterControler = GetComponent<CharacterController> ();
		myObject = transform;
		GameObject go = GameObject.FindWithTag ("Player");
		player = go.transform;
	}
	
	// Update is called once per frame
	void Update (){

		float distanceFromPlayer = Vector3.Distance (myObject.position, player.position);

		//Jeżeli dystans jaki dzieli obiekt wroga od obiektu gracza mieści się w zakresie widzenia wroga to 
		if (distanceFromPlayer < enemyRange && distanceFromPlayer > minDistanceFromPlayer && isAlive()) {

			Vector3 playerPosition = new Vector3(player.position.x, player.position.y, player.position.z);

			//Funkcja Quaternion.Slerp (spherical linear interpolation) pozwala obracać obiekt w zadanym kierunku z zadaną prędkością.
			myObject.rotation = Quaternion.Slerp (myObject.rotation, Quaternion.LookRotation (playerPosition - myObject.position), enemySpeed * Time.deltaTime);

		
			Vector3 move = new Vector3(myObject.forward.x, myObject.forward.y, myObject.forward.z);
			characterControler.Move(move * enemySpeed * Time.deltaTime);
		}

		if (!isAlive()) {
			if (audioSource != null)
				audioSource.Stop();
			
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
