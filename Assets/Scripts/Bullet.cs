using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	public Rigidbody2D rb;
	public GameObject hitCorrectTargetAnim;
	public GameObject hitWrongTargetAnim;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * speed;
		Destroy(gameObject, 4f);
	}

	//If it hits the wrong target, removes a life
	protected void WrongTarget(){
		GameObject wrongTargetAnimation = Instantiate(hitWrongTargetAnim, transform.position, transform.rotation);
		Destroy(wrongTargetAnimation, 1f);
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().TakeLife();
		Destroy(gameObject);
	}

	//Creates a bullet HitAnimation and destroys it after it finishes.
	protected void TargetHit(){
			GameObject correctTargetAnimation = Instantiate(hitCorrectTargetAnim, transform.position, transform.rotation);
			Destroy(correctTargetAnimation, 0.3f);
	}
}
