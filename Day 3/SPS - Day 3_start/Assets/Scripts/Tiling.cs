using UnityEngine;
using System.Collections;

public class Tiling : MonoBehaviour {

	public int offsetX=2;
	public bool hasArightImage = false;
	public bool hasAleftImage = false;
	private float spriteWidth = 0f;

	public Camera cam;
	private Transform transformMy;

	void Awake(){
		transformMy = transform;
	}

	// Use this for initialization
	void Start () {
		SpriteRenderer renderer = 
			GetComponent<SpriteRenderer> ();

		spriteWidth = transformMy.localScale.x *
			renderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (hasAleftImage == false 
		    || hasArightImage == false) {

			float camHorizontalExtend = 
				cam.orthographicSize * Screen.width/Screen.height;

			float edgeVisiblePositionRight = 
				(transformMy.position.x + spriteWidth/2) 
					- camHorizontalExtend;

			float edgeVisiblePositionLeft = 
				(transformMy.position.x - spriteWidth/2) 
					+ camHorizontalExtend;



			if(cam.transform.position.x 
			   >= edgeVisiblePositionRight - offsetX 
			   && hasArightImage == false)
			{
				makeNewImage(1);
				hasArightImage=true;

			}
			else if(cam.transform.position.x 
			        <= edgeVisiblePositionLeft + offsetX 
			        && hasAleftImage == false)
			{
				makeNewImage(-1);
				hasAleftImage=true;

			}

		}
	}

	void makeNewImage(int rightOrLeft){
		Vector3 newPosition = new Vector3 (
			transformMy.position.x + spriteWidth * rightOrLeft,
			transformMy.position.y, 
			transformMy.position.z);

		Transform newImage = 
			Instantiate (transformMy, newPosition, 
			             transformMy.rotation) 
				as Transform;

		newImage.parent = transformMy.parent;
		if (rightOrLeft > 0) {
			newImage.GetComponent<Tiling> ().hasAleftImage = true;
		} else {
			newImage.GetComponent<Tiling>().hasArightImage = true;
		}
	}

}
