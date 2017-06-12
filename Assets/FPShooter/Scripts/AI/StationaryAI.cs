using UnityEngine;
using System.Collections;

public class StationaryAI : BaseAI {

	private EnemyAttack attack;

	protected override void Start () {
		base.Start();
		attack = gameObject.GetComponent<EnemyAttack> ();
	}

	override protected void InRangeBehavior() {
		attack.doAttack ();
	}
	
}
