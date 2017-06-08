using UnityEngine;
using System.Collections;

public class BigGun : MonoBehaviour {

	public GameObject bigBullet;
	public float waitTime = 2f;

	private float time = 0f;

	public AudioSource audioSource;
	public AudioClip audioClip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;

		if(Input.GetMouseButton(1) && time <= 0){
			time = waitTime;

			if (audioSource != null)
				audioSource.PlayOneShot (audioClip);

			Instantiate(bigBullet, Camera.main.transform.position+Camera.main.transform.forward, Camera.main.transform.rotation);

		}
	}
}
