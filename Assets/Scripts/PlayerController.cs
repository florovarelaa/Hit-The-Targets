using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject firePoint;
	public int maxLives;
	public bool isDead;

	public GameObject bulletEnemy;
	public GameObject bulletBomb;

	// public float StartTimeBtwShoot;
	// public float timeBtwShoot;
	// private bool shooting;
	
	public int lives;

	// Use this for initialization
	void Start () {
		isDead = false;
		lives = maxLives;
	}
	
	// Update is called once per frame
	void Update () {
		faceMouse();
		if(Input.GetKeyDown(KeyCode.S)){
				ShootBulletEnemy();
		} else if(Input.GetKeyDown(KeyCode.A)){
				ShootBulletBomb();
		}
	}

	//Player Rotate to mouse position
	void faceMouse(){
		Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
	}

	//Shoot Bullet that kills enemies
	void ShootBulletEnemy(){
		Instantiate(bulletEnemy, firePoint.transform.position, transform.rotation);
	}

	//Shoot Bullet that kills bombs
	void ShootBulletBomb(){
		Instantiate(bulletBomb, firePoint.transform.position, transform.rotation);
	}

	//Remove a life
	public void TakeLife(){
		if(lives -1 == 0){
			Die();
		} else
			lives--;
	}

	//Gain a Life
	public void GiveLife(){
		if(lives < maxLives)
			lives++;
	}

	//Player dies
	void Die(){
		lives = 0;
		isDead = true;
		FindObjectOfType<GameController>().GameOver(true);
	}

	//check if player is shooting
	// void isShooting(){
	// 	if(timeBtwShoot <= 0 && !shooting){
	// 		timeBtwShoot = StartTimeBtwShoot;
	// 		shooting =  true;
	// 	} else {
	// 		timeBtwShoot -= Time.deltaTime;
	// 		shooting = false;
	// 	}
	// }

	void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.tag == "Enemy"){
			TakeLife();
			//FindObjectOfType<GameController>().AddToScore(-collider.GetComponent<EnemyController>().pointsOnCollision);
			Destroy(collision.gameObject);
		} else if(collision.gameObject.tag == "Bomb"){
			//FindObjectOfType<GameController>().AddToScore(-collider.GetComponent<EnemyController>().pointsOnCollision);
			Destroy(collision.gameObject);
			Die();
		}	
	}
}
