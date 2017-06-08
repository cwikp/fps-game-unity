using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {
	
	public float timeToLive = 1f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		timeToLive -= Time.deltaTime;
		
		if(timeToLive <=0){
			Destroy(gameObject);
		}
	
	}
}
