using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner {

	// Update is called once per frame
	void Update () {
		SpawnObject(objectToSpawn);
	}
}
