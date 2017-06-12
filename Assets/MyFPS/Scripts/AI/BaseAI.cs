using UnityEngine;
using System.Collections;

public abstract class BaseAI : MonoBehaviour {

	[SerializeField] protected float enemySpeed = 5.0f;
	[SerializeField] protected float enemyRange = 30.0f;
	[SerializeField] protected float minDistanceFromPlayer = 5.0f;
	[SerializeField] private AudioSource audioSource;

	protected Transform player;
	protected Transform enemy;
	private bool isRidgidBody = false;

	protected abstract void InRangeBehavior();

	protected virtual void Start () {
		enemy = transform;
		GameObject playerGameObject = GameObject.FindWithTag ("Player");
		player = playerGameObject.transform;
	}
	
	void Update () {
		if (player == null || enemy == null) return;

		float distanceFromPlayer = Vector3.Distance (enemy.position, player.position);
		if (distanceFromPlayer < enemyRange && distanceFromPlayer > minDistanceFromPlayer && isAlive()) {
			enemy.rotation = Quaternion.Slerp (
				enemy.rotation, 
				Quaternion.LookRotation (player.position - enemy.position), 
				enemySpeed * Time.deltaTime);
			InRangeBehavior();
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

	private bool isAlive(){
		Health health = gameObject.GetComponent<Health> ();

		if (health != null) {
			return health.isAlive();
		}

		return true;
	}

}
