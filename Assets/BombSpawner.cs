using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : Spawner {
	
	// Update is called once per frame
	void Update () {
		SpawnObject(objectToSpawn);
	}
}
