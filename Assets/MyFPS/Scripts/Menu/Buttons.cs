using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	// Use this for initialization

	public void PlayButton(string scene){
		SceneManager.LoadScene(scene);
	}

	public void QuitButton(){
		Application.Quit();
	}

}
