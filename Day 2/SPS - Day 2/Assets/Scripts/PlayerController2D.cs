using UnityEngine;
using System.Collections;

public class PlayerController2D : MonoBehaviour {

	public float maxSpeed = 10.0f;
	bool facingRight = true;

	bool grounded = false;
	// reference to another object which indicates where ground should be
	public Transform groundCheck;
	// size of the sphere in which we check for ground
	float groundRadius = 0.2f;
	// layer that represents ground
	public LayerMask whatIsGround;

	public float jumpForce = 100.0f;

	Animator animator;

	bool pushing = false;
	public Transform[] pushCheck;
	float pushRadius = 0.2f;
	public LayerMask whatIsPushable;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// FixedUpdate is called every physics step
	void FixedUpdate(){

		// constantly check if the groundCheck object overlaps with another object which represents ground
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		animator.SetBool ("Ground", grounded);

		//check if the player is grounded and jump key has been pressed
		if (grounded && Input.GetAxisRaw ("Jump") == 1) {
			animator.SetBool ("Ground", false);

			// make the rigidbody jump
			rigidbody2D.AddForce (new Vector2 (rigidbody2D.position.x, jumpForce), ForceMode2D.Impulse);

		}

		animator.SetFloat ("vSpeed", rigidbody2D.velocity.y);
	
		// storing the keyboard input in the move variable
		float move = Input.GetAxis ("Horizontal");

		animator.SetFloat("Speed",Mathf.Abs(move));

		// adding movement (velocity) to our rigidbody (Orc game object)
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		// checking in which direction is the rigidbody moving and if it needs to flip
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		pushing = false;

		foreach (var item in pushCheck) {
			pushing = pushing || Physics2D.OverlapCircle (item.position, pushRadius, whatIsPushable);
		}

		animator.SetBool ("Push", pushing);

	}
		

	// Flip the character
	void Flip(){

		// change our facing variable
		facingRight = !facingRight;

		// store the scale of our rigidbody to a variable
		Vector3 theScale = transform.localScale;

		// flip the stored scale
		theScale.x *= -1;

		// flip the game object
		transform.localScale = theScale;
	}
}
