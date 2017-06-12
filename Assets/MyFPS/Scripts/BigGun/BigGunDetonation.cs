using UnityEngine;
using System.Collections;

public class BigGunDetonation : MonoBehaviour {

	[SerializeField] private GameObject detonationObject;

	[SerializeField] private float damage = 200f;
	[SerializeField] private float range = 3f;

	void OnTriggerEnter(){
		detonation();
	}

	void detonation(){
		Vector3 detonationPoint = transform.position;
		
		if (detonationObject != null) {
			Instantiate(detonationObject, detonationPoint, Quaternion.identity);
		}

		Collider[] colliders = Physics.OverlapSphere (detonationPoint, range);

		foreach(Collider collider in colliders){			
			Health health = collider.GetComponent<Health>();
			if (health != null) {
				float dist = Vector3.Distance(detonationPoint, collider.transform.position);
				float distanceDamage = 1f - (dist / range); 
				health.receiveDamage(damage *  distanceDamage);
			}
		}
	}
}
