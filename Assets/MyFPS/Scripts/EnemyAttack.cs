using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	//Obiekt pocisku.
	public GameObject enemyBullet;

	private float waitTime = 2f;
	private float time = 0f;
	private GameObject player;


	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void doAttack (){
		Health health = player.GetComponent<Health> ();
		if (health.isAlive ()) {
			time -= Time.deltaTime;

			if (time <= 0) {
				time = waitTime;
				Instantiate (enemyBullet, transform.position + transform.forward, transform.rotation);
			}
		}
	}
}
