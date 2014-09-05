using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	public float movementSpeed;
	public KeyCode launch;
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(launch))
		{
			transform.parent = null;
			rigidbody2D.velocity = transform.TransformDirection(Vector2.one) * movementSpeed;
		}
	}	
}
