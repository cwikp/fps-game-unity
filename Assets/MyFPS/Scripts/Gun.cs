using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject bullet;

	public float gunRange = 100.0f;
	public float damage = 50.0f;
	public float waitTime = 0.5f;
	public float time = 0f;

	public AudioSource audioSource;
	public AudioClip audioClip;

	void Start () {
	
	}

	void Update () {
		
		if (time <waitTime) {
			time += Time.deltaTime;
		}

		if(Input.GetMouseButton(0) && time >= waitTime){
			time = 0;
	
			//pobranie kierunku w ktorym skierowana jest kamera
			Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
			RaycastHit hitInfo; 	// w co zostal oddany strzal.
		
			if(Physics.Raycast(ray, out hitInfo, gunRange)){
				Vector3 hitPoint = hitInfo.point;
				GameObject gameObject = hitInfo.collider.gameObject;

				hit(gameObject);

				if (audioSource != null)
					audioSource.PlayOneShot (audioClip);

				if(bullet != null){
					//utworzenie obiektu pocisku w momencie trafienia celu.
					Instantiate(bullet, hitPoint, Camera.main.transform.rotation);
				}
				
			}
		}
	}
		
	void hit( GameObject go){
		Health health = go.GetComponent<Health>();
		if(health != null) {
			health.receiveDamage(damage);
		}
	}
}
