using UnityEngine;
using System.Collections;

public class BigGunDetonation : MonoBehaviour {

	public GameObject detonationObject;

	public float damage = 200f;
	public float range = 3f;


	void OnTriggerEnter(){
		detonation();
	}

	void detonation(){
		Vector3 detonationPoint = transform.position;
		
		if (detonationObject != null) {
			Instantiate(detonationObject, detonationPoint, Quaternion.identity);
			
		}
		//var exp = GetComponent<ParticleSystem>();
		//exp.Play ();
		//if(gameObject != null)
			//Destroy (gameObject);

		//Pobranie wszystkich obiektów w zasięgu pola rażenia pocisku.
		Collider[] colliders = Physics.OverlapSphere (detonationPoint, range);

		foreach(Collider c in colliders){			
			Health health = c.GetComponent<Health>();
			if(health != null) {
				float dist = Vector3.Distance(detonationPoint, c.transform.position);
				//Obliczenie obrażeń zgodnie z odstępem od pocisku. Im bliżej tym obrażenia większe im dalej tym mniejsze.
				float distanceDamage = 1f - (dist / range); 
				health.receiveDamage(damage *  distanceDamage);
			}
			
		}
	}
}
