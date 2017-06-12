using UnityEngine;
using System.Collections;

public class BigGun : MonoBehaviour {

	[SerializeField] private GameObject bigBullet;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip audioClip;
	[SerializeField] private float waitTime = 2f;

	private float time = 0f;

	void Update () {
		time -= Time.deltaTime;

		if(Input.GetMouseButton(1) && time <= 0){
			time = waitTime;

			if (audioSource != null)
				audioSource.PlayOneShot (audioClip);

			Instantiate(
				bigBullet, 
				Camera.main.transform.position + Camera.main.transform.forward, 
				Camera.main.transform.rotation);
		}
	}
}
