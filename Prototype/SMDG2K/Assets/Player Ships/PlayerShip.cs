using UnityEngine;

public class PlayerShip : MonoBehaviour 
{
	public float movementSpeed;
	public KeyCode moveLeft;
	public KeyCode moveRight;

	private bool touchingLeftWall, touchingRightWall;
	private GameObject pivot;
	// Use this for initialization
	void Start () 
	{
		// Player Ship always starts in middle, so it will never touch walls at beginning of game
		touchingRightWall = false;
		touchingLeftWall = false;
		pivot = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	// FixedUpdate is called once per PhysicsFrame
	void FixedUpdate()
	{
		//Update movement if not moving against wall
		if(!touchingRightWall && Input.GetKey(moveRight))
		{
			pivot.transform.Rotate(0f, 0f, -movementSpeed);
			//transform.RotateAround(Vector3.zero, Vector3.forward, -movementSpeed);
		}
		else if(!touchingLeftWall && Input.GetKey(moveLeft))
		{
			pivot.transform.Rotate(0f, 0f, movementSpeed);
			//transform.RotateAround(Vector3.zero, Vector3.forward, movementSpeed);
		}
		else if(touchingRightWall && Input.GetKey(moveLeft))
		{
			pivot.transform.Rotate(0f, 0f, movementSpeed);
			//transform.RotateAround(Vector3.zero, Vector3.forward, movementSpeed);
		}
		else if(touchingLeftWall && Input.GetKey(moveRight))
		{
			pivot.transform.Rotate(0f, 0f, -movementSpeed);
			//transform.RotateAround(Vector3.zero, Vector3.forward, -movementSpeed);
		}
	}

	// Triggers When Colliders Enter Trigger Zone
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Right Wall")
		{
			touchingRightWall = true;
		}
		else if(coll.gameObject.tag == "Left Wall")
		{
			touchingLeftWall = true;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Right Wall")
		{
			touchingRightWall = false;
		}
		else if(coll.gameObject.tag == "Left Wall")
		{
			touchingLeftWall = false;
		}
	}
}
