using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {
	
	public GameObject target;
	public float xOffset = 0;
	public float yOffset = 0;
	public float zOffset = 0;
	
	void LateUpdate() {
		this.transform.position = new Vector3(target.transform.position.x + xOffset,
		                                      transform.position.y,
		                                      target.transform.position.z + transform.position.z);
	}
}
