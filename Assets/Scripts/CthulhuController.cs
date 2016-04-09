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
		scared = true;


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

	void OnCollisionEnter2D(Collision2D anything)
	{
		chooseDirection ();
	}

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
		this.transform.position += direction * speed * Time.deltaTime;
	}
}
