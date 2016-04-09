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

	void Awake ()
	{
		hits = 0;
		direction = new Vector3 (1f, 1f, 0);
		playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;


	}
	// Use this for initialization
	void Start () {
		//InvokeRepeating ("chooseDirection", 2f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		if (hits >= hitsTillScared)
			scared = true;

		//move
		playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
		chooseDirection ();
		move ();
	}

	void OnTriggerEnter2D(Collider2D lightCollision)
	{
		if (lightCollision.gameObject.tag == "Light") {
			//do stuff

		}
	}

//	void OnCollisionEnter2D(Collider2D anything)
//	{
//		chooseDirection ();
//	}

	public void shootMonster()
	{
		++hits;
	}

	private void chooseDirection()
	{
		direction = playerPos - this.transform.position;
		direction = direction.normalized;
		
		if (scared)
			direction = -direction;


	}

	private void move()
	{
		Vector3 rayDir3 = playerPos - this.transform.position;
		Vector2 rayDir2 = new Vector2 (rayDir3.x, rayDir3.y);
		Debug.DrawRay(this.transform.position, rayDir3, Color.red);
		RaycastHit2D hit = Physics2D.Raycast (new Vector2 (this.transform.position.x, this.transform.position.y), rayDir2);

		if (hit.collider.tag == "Player") {
			this.transform.position += direction * speed * Time.deltaTime;
			float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

		}

		

	}
}
