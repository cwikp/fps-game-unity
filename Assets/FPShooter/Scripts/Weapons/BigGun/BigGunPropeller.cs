using UnityEngine;
using System.Collections;

public class BigGunPropeller : MonoBehaviour {

	[SerializeField] private float speed = 10f;
		
	void FixedUpdate () {
		transform.Translate (transform.forward * speed * Time.deltaTime, Space.World);
	}
	
}
