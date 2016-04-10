using UnityEngine;
using System.Collections;

public class CthulhuController : MonoBehaviour {

	private int hits;
	private GameObject current;
	public bool scared;
	public int hitsTillScared;
	public float speed;
	private Vector3 direction;
	private Vector3 playerPos;
	private bool beingStaredAt;
	public float timeTillPenalty;
	private float timeTillPenaltyReset;
	private bool penalize = false;

	void Awake ()
	{
		hits = 0;
		direction = playerPos - this.transform.position;
		playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
		beingStaredAt = false;
		timeTillPenaltyReset = timeTillPenalty;


	}
	// Use this for initialization
	void Start () {
		//InvokeRepeating ("chooseDirection", 2f, 2f);

	}
	
	// Update is called once per frame
	void Update () {
		if (hits >= hitsTillScared) {
			scared = true;
			hits = 0;
		}

		//move
		playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
		chooseDirection ();
		move ();

		if (beingStaredAt)
			timeTillPenalty -= Time.deltaTime;

		if (timeTillPenalty <= 0.0)
			penalize = true;


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Light") {
			beingStaredAt = true;
		}

		if (other.gameObject.tag == "Bolt") {
			++hits;
		}
	}

	void OnTriggerExit2D(Collider2D lightCollision)
	{
		if (lightCollision.gameObject.tag == "Light") {

			timeTillPenalty = timeTillPenaltyReset;
			beingStaredAt = false;
			penalize = false;
		}
	}

	void OnCollisionEnter2D(Collision2D anything)
	{
		//chooseDirection ();
	}

	public void shootMonster()
	{
		++hits;
	}

	private void chooseDirection()
	{
		Vector3 newDirection = playerPos - this.transform.position;


		if (scared)
			newDirection = -newDirection; 

		Vector2 rayDir2 = (Vector2)newDirection;
		Debug.DrawRay(this.transform.position, newDirection, Color.red);
		RaycastHit2D hit = Physics2D.Raycast ((Vector2)this.transform.position, rayDir2, 5f);

		if (hit.collider == null || hit.collider.tag == "Player") {
				direction = newDirection;
			} else if (hit.collider.tag == "Wall") {
			
			direction = pathAround (newDirection);
			}

		float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		direction = direction.normalized;

	}

	private Vector3 pathAround(Vector3 target)
	{
		Vector3 tangent = Vector3.Cross (target, Vector3.forward);

		int numTests = 5;
		float min = Mathf.Infinity;

//		for (int i = 0; i < numTests; ++i) {
//
//
//			if (runGap < min)
//				min = runGap;
//		}

		return tangent;
	}

	private void move()
	{
		this.transform.position += direction * speed * Time.deltaTime;

	}

	public bool penalty()
	{
		if (!scared)
			return penalize;
		else {
			scared = false;
			timeTillPenalty = timeTillPenaltyReset;
			return false;
		}
	}
}
