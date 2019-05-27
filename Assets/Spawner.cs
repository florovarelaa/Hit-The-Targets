using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour {

	public float startTimeBtwSpawn;
	public GameObject objectToSpawn;

	private float radius;
	private float timeBtwSpawn;

	void Start() {
		var verticalSize = Camera.main.orthographicSize * 2f;
		var horizontalSize = verticalSize * Screen.width / Screen.height;

		radius = (Mathf.Sqrt(Mathf.Pow(horizontalSize,2) + Mathf.Pow(verticalSize,2))) / 2;
	}

	//Spawns an object after certain time on a random point
	protected void SpawnObject(GameObject objectToSpawn){
		if(timeBtwSpawn <= 0){
			Instantiate(objectToSpawn, SelectRandomPoint(), Quaternion.identity);
			timeBtwSpawn = startTimeBtwSpawn;
		} else {
			timeBtwSpawn -= Time.deltaTime;
		}
	}

	//selects a random point from across the camera
	Vector3 SelectRandomPoint(){
		float angle = (Random.value * 360f) * Mathf.Deg2Rad;
		var x = Mathf.Cos(angle);
		var y = Mathf.Sin(angle);
		var pos = new Vector3(x, y, 0);
		pos = pos * radius;
		return pos;
	}
}
