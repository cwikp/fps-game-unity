using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {
	
	[SerializeField] private float timeToLive = 1f;

	void Update () {
		timeToLive -= Time.deltaTime;
		if (timeToLive <=0) {
			Destroy(gameObject);
		}
	}

}
