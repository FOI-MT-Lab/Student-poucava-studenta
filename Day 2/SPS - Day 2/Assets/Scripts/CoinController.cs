using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	public int scoreValue = 1;
	AudioSource audioSource;
	SpriteRenderer spriteRenderer;
	CircleCollider2D circleCollider2D;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		circleCollider2D = GetComponent<CircleCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player" /*&& !audioSource.isPlaying*/) {
			audioSource.Play ();
			spriteRenderer.enabled = false;
			circleCollider2D.enabled = false;
			//ScoreManager.score += scoreValue;
			Destroy (gameObject, audioSource.clip.length);
		}
	}
}
