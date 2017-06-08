using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float currentHealth = 100.0f;

	public void receiveDamage(float hitPoints) {
		currentHealth -= hitPoints;
	}
	
	public void Die(){
		Destroy(gameObject);	
	}

	public bool isAlive(){
		if (currentHealth <= 0) {
			return false;
		}
		return true;
	}
}
