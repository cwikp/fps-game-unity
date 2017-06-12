using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	public void PlayButton(string scene){
		SceneManager.LoadScene(scene);
	}

	public void QuitButton(){
		Application.Quit();
	}

}
