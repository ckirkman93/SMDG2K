using UnityEngine;
using System.Collections;

public class PaddleControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float dir = Input.GetAxis ("Horizontal") * 1.5f;
		transform.Rotate(new Vector3(0f, 0f, -dir));
	}
}
