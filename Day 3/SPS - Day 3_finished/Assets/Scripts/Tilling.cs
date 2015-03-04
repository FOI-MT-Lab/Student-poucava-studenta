using UnityEngine;
using System.Collections;

//Attach component
[RequireComponent (typeof(SpriteRenderer))]

public class Tilling : MonoBehaviour {
	
	public int offsetX = 2; //set little offset to check a == b 
	
	//these are used for checking if we need to instantiate objects
	public bool hasArightImage = false;
	public bool hasAleftImage = false;
	public bool reverseScale = false; //this is for non tilable backgroound elements
	
	private float spriteWidth = 0f; //the width of object
	private Camera cam;
	private Transform transformMy;
	
	private const int rightImage = 1;
	private const int leftImage = -1;
	
	
	void Awake(){
		cam = Camera.main;
		transformMy = transform;
	}
	
	// Use this for initialization
	void Start () {
		//get sprite renderer of this object
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		spriteWidth = transformMy.localScale.x  * renderer.sprite.bounds.size.x;
		
	}
	
	// Update is called once per frame
	void Update () {
		//checking does it still need near images
		if(hasAleftImage == false || hasArightImage == false){
			//calculate the length of center camera to point b (half the width of what the camera can see)
			float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;
			//calculate the x position where the camera can see the edge of the sprite
			float edgeVisiblePositionRight = (transformMy.position.x + spriteWidth / 2) - camHorizontalExtend; //position of b
			float edgeVisiblePositionLeftt = (transformMy.position.x - spriteWidth / 2) + camHorizontalExtend; //position of
			
			//if b >= a (- offset)...checking if we can see the edge of element and then calling makeNewImage
			if(cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasArightImage == false)
			{
				makeNewImage(rightImage);
				hasArightImage = true;
			}
			//if b <= a (+ offset)
			else if(cam.transform.position.x <= edgeVisiblePositionLeftt + offsetX && hasAleftImage == false)
			{
				makeNewImage(leftImage);
				hasAleftImage = true;
			}
		}
	}
	
	void makeNewImage(int rightOrLeft)
	{
		//calculate new position for image
		Vector3 newPosition = new Vector3 (transformMy.position.x + spriteWidth * rightOrLeft, transformMy.position.y, transformMy.position.z);
		//Insantiate new image and store this in variable
		Transform newImage = Instantiate (transformMy, newPosition, transformMy.rotation) as Transform;
		
		//inverse image on x axis
		if (reverseScale == true) 
		{
			newImage.localScale = new Vector3(newImage.localScale.x * -1, newImage.localScale.y,newImage.localScale.z);
		}
		newImage.parent = transformMy.parent;
		//Set boolean which track if image has left or right instantiated images
		if (rightOrLeft > 0) {
			newImage.GetComponent<Tilling> ().hasAleftImage = true;
		} else 
		{
			newImage.GetComponent<Tilling>().hasArightImage = true;
		}
		
		
	}
	
}
