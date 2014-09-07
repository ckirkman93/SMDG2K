using UnityEngine;

public class PlayerShip : MonoBehaviour 
{
	public float movementSpeed;
	public KeyCode moveLeft;
	public KeyCode moveRight;
	public KeyCode createBall;
	public KeyCode launchBall;
	public Ball ballPreFab;

	private bool touchingLeftWall, touchingRightWall;
	private GameObject pivot;
	private Ball currentBall;

	// Use this for initialization
	void Start () 
	{
		// Player Ship always starts in middle, so it will never touch walls at beginning of game
		touchingRightWall = false;
		touchingLeftWall = false;
		pivot = this.transform.parent.gameObject;
		currentBall = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(createBall) && currentBall == null)
		{
			// Determine inital location of ball in relation to paddle
			Vector3 currentPosition = transform.position + transform.position.normalized * 0.15f;

			// Create ball
			currentBall = (Ball) Instantiate(ballPreFab, currentPosition, transform.rotation);

			// Adjust scale of ball, attach it to paddle, and enable object
			currentBall.transform.parent = transform;
			currentBall.transform.localScale = new Vector3(2.0f, 0.5f, 0.0f);
			currentBall.gameObject.SetActive(true);
		}

		if(Input.GetKey(launchBall) && currentBall != null  && currentBall.transform.IsChildOf(transform))
		{
			currentBall.Launch(3.0f);
		}
	}

	// FixedUpdate is called once per PhysicsFrame
	void FixedUpdate()
	{
		//Update movement if not moving against wall
		if(!touchingRightWall && Input.GetKey(moveRight))
		{
			pivot.transform.Rotate(0f, 0f, -movementSpeed); //Rotate parent the amount of degrees
			//transform.RotateAround(Vector3.zero, Vector3.forward, -movementSpeed);
		}
		else if(!touchingLeftWall && Input.GetKey(moveLeft))
		{
			pivot.transform.Rotate(0f, 0f, movementSpeed); //Rotate parent the amount of degrees
			//transform.RotateAround(Vector3.zero, Vector3.forward, movementSpeed);
		}
		else if(touchingRightWall && Input.GetKey(moveLeft))
		{
			pivot.transform.Rotate(0f, 0f, movementSpeed); //Rotate parent the amount of degrees
			//transform.RotateAround(Vector3.zero, Vector3.forward, movementSpeed);
		}
		else if(touchingLeftWall && Input.GetKey(moveRight))
		{
			pivot.transform.Rotate(0f, 0f, -movementSpeed); //Rotate parent the amount of degrees
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
