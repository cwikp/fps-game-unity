using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerGenerator : MonoBehaviour {

	[SerializeField] private Transform startCube;
	[SerializeField] private Transform enemy;

	[SerializeField] private int cubesNumber = 100;
	[SerializeField] private int minXCubeSpacing = 5;
	[SerializeField] private int maxXCubeSpacing = 10;
	[SerializeField] private int minZCubeSpacing = 5;
	[SerializeField] private int maxZCubeSpacing = 10;
	[SerializeField] private float cubeYSpacing = 2.0f;
	
	private List<TowerCube> cubes = new List<TowerCube>();

	void Start () {
		Transform previousCube = startCube;
		for (int i=0; i<cubesNumber; i++) {
			var xPos = previousCube.position.x + GetRandomNumber(minXCubeSpacing, maxXCubeSpacing);
			var yPos = previousCube.position.y + cubeYSpacing;
			var zPos = previousCube.position.z + GetRandomNumber(minZCubeSpacing, maxZCubeSpacing);

			Transform newCube = (Transform) Instantiate(
				startCube, 
				new Vector3(xPos, yPos, zPos), 
				Quaternion.identity);

			cubes.Add(new TowerCube(newCube, GetRandomBehavior()));
			previousCube = newCube;

			if (i%10 == 0){
				spawnEnemy(newCube.position);
			}
		}
	}

	private void spawnEnemy(Vector3 vector){
		vector.x += 10;
		Instantiate(
				enemy, 
				vector, 
				Quaternion.identity);
	}

	private float GetRandomNumber(float min, float max){
		var random = Random.Range(min, max);
		var minusRandom = Random.Range(0, 10);
		if (minusRandom > 5.0f){
			random = -random;
		}
		return random;
	}

	private CubeBehavior GetRandomBehavior(){
		var random = Random.Range(0, 100);
		if (random < 10) return CubeBehavior.ROTATE;
		else if (random < 20) return CubeBehavior.MOVE_HORIZONTALLY;
		else if (random < 30) return CubeBehavior.MOVE_VERTICALLY;
		else return CubeBehavior.NONE;
	}
	
	void Update () {
		foreach (TowerCube cube in cubes){
			cube.applyBeahavior();
		}
	}
	
}
