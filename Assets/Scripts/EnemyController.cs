using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float speed;

	private Transform target;

	public int points;
	public int pointsOnCollision;
	

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		MoveToPlayer();
	}

	//Move to player
	private void MoveToPlayer(){
		transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

		var dir = target.position - transform.position;
 		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
 		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
