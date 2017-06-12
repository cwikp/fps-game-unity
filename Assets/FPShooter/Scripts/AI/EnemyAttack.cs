using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	[SerializeField] private GameObject enemyBullet;
	[SerializeField] private float waitTime = 2f;
	
	private float time = 0f;
	private GameObject player;

	void Start () {
		player = GameObject.FindWithTag ("Player");
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
