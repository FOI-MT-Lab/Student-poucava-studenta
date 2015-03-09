using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInteractin : MonoBehaviour {
	public int rezultat = 0;
	public Text score;
	public int requiredScore = 3; 


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Coin") {
			audio.Play();
			other.gameObject.SetActive(false);
			rezultat++;
			score.text = rezultat.ToString();

			if(rezultat >= requiredScore)
				Invoke("LoadLevel", 2.0f);
		}
	}

	void LoadLevel(){
		Application.LoadLevel("Jura");
	}

}
