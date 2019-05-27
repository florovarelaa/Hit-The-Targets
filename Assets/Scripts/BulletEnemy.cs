﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet {

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag == "Enemy"){
			//hits a bomb, bullet and enemy are destroyed
			Destroy(collider.gameObject);
			Destroy(gameObject);
			TargetHit();
			//FindObjectOfType<GameController>().AddToScore(- collider.GetComponent<EnemyController>().points);
		} else if(collider.gameObject.tag == "Bomb"){
			//hits an enemy, removes a life from the player
			//FindObjectOfType<GameController>().AddToScore(- collider.GetComponent<EnemyController>().points);
			WrongTarget();
		}
	}
}
