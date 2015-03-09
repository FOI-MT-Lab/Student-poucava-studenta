using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public GameObject target;

	// Update is called once per frame
	void Update () {
		transform.position =
			new Vector3 (target.transform.position.x,
			            transform.position.y,
			            target.transform.position.z 
			             + transform.position.z);

	}
}
