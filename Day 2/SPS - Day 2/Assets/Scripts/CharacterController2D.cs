using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour {

	public float maxSpeed = 10.0f;
	bool facingRight = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// FixedUpdate is called every physics step
	void FixedUpdate (){

		// storing the keyboard input in the move variable (-1 or 1)
		float move = Input.GetAxis ("Horizontal");

		// adding movement (velocity) to our rigidbody (Orc) using a vector
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		// checking in which direction is the rigidbody moving and if it needs to flip
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}

	// Flip the character
	void Flip(){
		// change our facing variable
		facingRight = !facingRight;
		// store the scale of our rigidbody to theScale variable
		Vector3 theScale = transform.localScale;
		// flip the stored scale
		theScale.x *= -1;
		// flip the rigidbody
		transform.localScale = theScale;
	}
}
