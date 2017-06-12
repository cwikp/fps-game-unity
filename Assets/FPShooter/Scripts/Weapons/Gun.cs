using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	[SerializeField] private GameObject bullet;

	[SerializeField] private float gunRange = 100.0f;
	[SerializeField] private float damage = 50.0f;
	[SerializeField] private float waitTime = 0.5f;
	[SerializeField] private float time = 0f;

	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip audioClip;

	void Start () {}

	void Update () {
		if (time < waitTime) {
			time += Time.deltaTime;
		}

		if (Input.GetMouseButton(0) && time >= waitTime){
			time = 0;
	
			Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
			RaycastHit hitInfo; 
		
			if (Physics.Raycast(ray, out hitInfo, gunRange)){
				Vector3 hitPoint = hitInfo.point;
				GameObject gameObject = hitInfo.collider.gameObject;

				hit(gameObject);

				if (audioSource != null)
					audioSource.PlayOneShot (audioClip);

				if(bullet != null){
					Instantiate(bullet, hitPoint, Camera.main.transform.rotation);
				}
			}
		}
	}
		
	void hit(GameObject go){
		Health health = go.GetComponent<Health>();
		if (health != null) {
			health.receiveDamage(damage);
		}
	}
}
