using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	[SerializeField] private float currentHealth = 100.0f;

	public void receiveDamage(float hitPoints) {
		currentHealth -= hitPoints;
	}

	public float GetCurrentHealth(){
		return currentHealth;
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
