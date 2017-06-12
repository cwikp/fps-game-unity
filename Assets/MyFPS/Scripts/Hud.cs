using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hud : MonoBehaviour {

	[SerializeField] private Text healthPercentage;
	[SerializeField] private Scrollbar healthBar;

	public void SetHealthPercentage(float percent){
		if (percent < 0) {
			percent = 0.0f;
		}
		healthPercentage.text = ((int) percent).ToString() + "%";
		healthBar.size = percent / 100.0f;
	}

}
