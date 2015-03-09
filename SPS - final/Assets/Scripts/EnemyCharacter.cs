using UnityEngine;
using System.Collections;

public class EnemyCharacter : MonoBehaviour {

	public float speed = 2f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2 (transform.localScale.x * speed, rigidbody2D.velocity.y);
	}

	void Flip()
	{
		Vector3 scaleEnemy = transform.localScale;
		scaleEnemy.x *= -1;
		transform.localScale = scaleEnemy;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log("lala");
		if (coll.gameObject.tag == "Obstacle") {
			Flip();
		}
	}
}
