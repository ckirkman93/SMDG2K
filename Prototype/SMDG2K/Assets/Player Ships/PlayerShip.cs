using UnityEngine;

public class PlayerShip : MonoBehaviour 
{
	public float movementSpeed, tractorSpeed;
	public KeyCode moveLeft;
	public KeyCode moveRight;
	public KeyCode createBall;
	public KeyCode launchBall;
	public Ball ballPreFab;
	public Transform reticlePreFab;

	private bool touchingLeftWall, touchingRightWall;
	private bool targetAcquired;
	private bool ballInTractorBeam;
	private GameObject pivot;
	private Ball currentBall;
	private Transform targetReticle;
	private GameObject currentTarget;

	// Use this for initialization
	void Start () 
	{
		// Player Ship always starts in middle, so it will never touch walls at beginning of game
		touchingRightWall = false;
		touchingLeftWall = false;
		pivot = this.transform.parent.gameObject;
		currentBall = null;
		targetReticle = (Transform) Instantiate(reticlePreFab);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(createBall) && currentBall == null && targetAcquired)
		{
			// Determine inital location of ball in relation to paddle

			// Create ball
			if(currentTarget != null)
			{
				// Destroy enemy and create a ball in its location
				targetReticle.gameObject.SetActive(false);
				Destroy(currentTarget.gameObject);
				currentBall = (Ball) Instantiate(ballPreFab, targetReticle.position, transform.rotation);

				// Adjust scale of ball and enable object
				currentBall.transform.localScale = new Vector3(0.20f, 0.20f, 0.0f);
				currentBall.gameObject.SetActive(true);

				// Ball is now in tractor beam
				ballInTractorBeam = true;
			}
		}

		if(ballInTractorBeam)
		{
			// Determine target location on paddle that ball is moving towards
			Vector3 targetPosition = transform.position + transform.position.normalized * 0.15f;

			// Move the ball towards the object
			currentBall.transform.position = Vector3.MoveTowards(currentBall.transform.position, targetPosition, tractorSpeed);

			// If object has arrived at destination, the object is attached and no longer in tractor beam
			if(currentBall.transform.position == targetPosition)
			{
				currentBall.transform.parent = transform;
				ballInTractorBeam = false;
			}
		}

		if(Input.GetKey(launchBall) && currentBall != null  && currentBall.transform.IsChildOf(transform) && !ballInTractorBeam)
		{
			currentBall.Launch(3.0f);
		}
	}

	// FixedUpdate is called once per PhysicsFrame
	void FixedUpdate()
	{
		//Raycast at enemy to determine current target
		if(currentBall == null)
		{
			//Offset ray's initial location
			Vector3 currentPosition = transform.position + transform.position.normalized * 0.15f;

			//Cast ray out of middle of paddle forward
			RaycastHit2D hit = Physics2D.Raycast(currentPosition, transform.TransformDirection(Vector2.up));

			//If collider is an enemy, place the reticle on the enemy
			if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
			{
				// Determine distance between paddle and enemy
				float distance = Vector3.Distance(hit.collider.transform.position, transform.position);

				// Determine if enemy is withing range of beam
				if(distance <= 2.0f)
				{
					targetAcquired = true;
					targetReticle.position = hit.transform.position;
					targetReticle.gameObject.SetActive(true);
					currentTarget = hit.collider.gameObject;
				}
			}
			else
			{
				// If the ray hits nothing, no enemy is withing range and the reticle turns off
				currentTarget = null;
				targetAcquired = false;
				targetReticle.gameObject.SetActive(false);
			}
		}

		// Update movement if not moving against wall
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
