using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

	[SerializeField] private Texture2D crosshairTexture; 
	[SerializeField] private bool isVisible = true;
	
	private Rect position; 
	
	void Start(){
		position = new Rect(
			(Screen.width - crosshairTexture.width) / 2, 
			(Screen.height - crosshairTexture.height) /2, 
			crosshairTexture.width, crosshairTexture.height);
	}
		
	void OnGUI(){
		if (isVisible == true) {
			GUI.DrawTexture (position, crosshairTexture); 
		}
	}
	
}
