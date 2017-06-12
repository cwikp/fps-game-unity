using UnityEngine;
using System.Collections;

public class ShootingAI : BaseAI {

	private CharacterController characterControler;
	private EnemyAttack attack;

	protected override void Start () {
		base.Start();
		characterControler = GetComponent<CharacterController> ();
		attack = gameObject.GetComponent<EnemyAttack> ();
	}

	override protected void InRangeBehavior() {
		Vector3 move = enemy.forward;
		characterControler.Move(move * enemySpeed * Time.deltaTime);
		attack.doAttack ();
	}
	
}
