using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	//array that store all the elements that we nned to aply parallax
	public Transform[] images;
	//list of object scales
	private float[] scalesParallax;
	public float smoothing = 1;
	//reference to main camera transform
	private Transform camera;
	//store te position of the camera previous frame
	private Vector3 previousCamePosition;

	//Called before Start, good for references between scripts and objects
	void Awake(){
		camera = Camera.main.transform;
	}


	// Use this for initialization
	void Start () {
		//The previous frame had the current frame's camera position
		previousCamePosition = camera.position;

		//assigning coresponding parallax scales
		scalesParallax = new float[images.Length];
		for (int i = 0; i < images.Length; i++) {
			scalesParallax[i] = images[i].position.z * -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < images.Length; i++) {
			//the parallax is the oposite of the camera movement because the previous frame multiplied by the scale
			float parallax = (previousCamePosition.x - camera.position.x) * scalesParallax[i];

			//set a target x position which is the current position + parallax
			float backgroundTargetPositionX = images[i].position.x + parallax;

			//create a target position which is the background's current position with its target x position
			Vector3 backgroundTargetPosition = new Vector3(backgroundTargetPositionX, images[i].position.y, images[i].position.z);

			//fade between current position and the target position using lerp
			images[i].position = Vector3.Lerp(images[i].position, backgroundTargetPosition, smoothing * Time.deltaTime);
		}

		//set the previousCamPosition to the cameras position at the end of the frame
		previousCamePosition = camera.position;
	}
}
