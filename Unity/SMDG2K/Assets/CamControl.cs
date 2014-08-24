using UnityEngine;
using System.Collections;

public class CamControl : MonoBehaviour {
	public GameObject pivot;
	private float ymin = 11.73f, ymax = 12.43f, zmin = 8.55f, zmax = 6.70f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (pivot.transform.rotation.eulerAngles.z < 325.0f && pivot.transform.rotation.eulerAngles.z > 45.0f) {
				this.camera.orthographicSize = zmin;
				transform.position = new Vector3(0f, ymin, -10f);
			///Debug.Log("small");
			} 
		else {
				this.camera.orthographicSize = zmax;
				transform.position = new Vector3(0f, ymax, -10f);
			//Debug.Log("large");
		}
	}
}
