using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

	public Texture2D crosshairTexture; 
	public bool isVisible = true;
	
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
