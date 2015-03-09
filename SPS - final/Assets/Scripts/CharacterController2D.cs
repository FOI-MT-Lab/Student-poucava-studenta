using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour {

	public float maxSpeed = 10.0f;
	bool facingRight = true;
	Animator animator;
	public float jumpForce = 100.0f;

	bool grounded = false;
	// reference to another object which indicates where ground should be
	public Transform groundCheck;
	// size of the sphere in which we check for ground
	float groundRadius = 0.2f;
	// layer that represents ground
	public LayerMask whatIsGround;

//	bool doubleJump = true;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		// check if the player is grounded and jump has been pressed
		// Input.GetKeyDown(KeyCode.Space)

	}

	// FixedUpdate is called every physics step
	void FixedUpdate (){

		if (/*(*/grounded /*|| doubleJump)*/ &&  Input.GetAxisRaw("Jump") == 1) {
			// player is no longer on the ground
			animator.SetBool ("Ground", false);
			
			// make the rigidbody jump
			rigidbody2D.AddForce (new Vector2 (rigidbody2D.position.x, jumpForce),ForceMode2D.Impulse);
			
			//			if (!grounded && doubleJump)
			//				doubleJump = false;
		}

		// constantly check if player is on ground
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		animator.SetBool ("Ground", grounded);

//		if (grounded)
//			doubleJump = true;

		animator.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		// storing the keyboard input in the move variable (-1 or 1)
		float move = Input.GetAxis ("Horizontal");

		animator.SetFloat ("Speed", Mathf.Abs(move));

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
