using UnityEngine;
using System.Collections;

public class FollowingAI : BaseAI {

	private CharacterController characterControler;
	
	protected override void Start () {
		base.Start();
		characterControler = GetComponent<CharacterController> ();
	}

	override protected void InRangeBehavior(){
		Vector3 move = enemy.forward;
		characterControler.Move(move * enemySpeed * Time.deltaTime);
	}
	
}
