using UnityEngine;
using System.Collections;

public class TowerCube {

	private float MAX_XPOS_CHANGE = 4.0f;
	private float MAX_YPOS_CHANGE = 1.0f;
	private float STEP = 0.05f;

	private Transform transform;
	private Vector3 originalPosition;
	private CubeBehavior behavior;
	
	private Vector3 changeXPos;
	private Vector3 changeYPos;

	public TowerCube(Transform transform, CubeBehavior behavior){
		this.transform = transform;
		originalPosition = transform.position;
		this.behavior = behavior;

		changeXPos = new Vector3(STEP, 0, 0);
		changeYPos = new Vector3(0, STEP, 0);
	}

	public void applyBeahavior(){
		switch(behavior){
			case CubeBehavior.MOVE_HORIZONTALLY: 
				moveHorizontally();
				break;
			case CubeBehavior.MOVE_VERTICALLY: 
				moveVertically();
				break;
			case CubeBehavior.ROTATE: 
				rotateCube();
				break;
			default: 
				break;
		}
	}

	private void rotateCube(){
		transform.Rotate(Vector3.right);
	}

	private void moveVertically(){
		if(transform.position.y > originalPosition.y + MAX_XPOS_CHANGE || 
			transform.position.y < originalPosition.y - MAX_XPOS_CHANGE){
			changeYPos.y = -changeYPos.y;
		}
		transform.position += changeYPos;
	}

	private void moveHorizontally(){
		if(transform.position.x > originalPosition.x + MAX_YPOS_CHANGE || 
			transform.position.x < originalPosition.x - MAX_YPOS_CHANGE){
			changeXPos.x = -changeXPos.x;
		}
		transform.position += changeXPos;
	}
	
}
