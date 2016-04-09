using UnityEngine;
using System.Collections;

public class CthulhuController : MonoBehaviour {

	private int hits;
	private GameObject current;
	private bool scared;
	public int hitsTillScared;
	public float speed;
	private Vector3 direction;

	void Awake ()
	{
		current = this;
		hits = 0;
		direction = new Vector3 (1f, 1f, 0);


	}
	// Use this for initialization
	void Start () {
		InvokeRepeating ("chooseDirection", 2f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		if (hits >= hitsTillScared)
			scared = true;

		move ();
	}

	void OnTriggerEnter2D(Collider2D lightCollision)
	{
		if (lightCollision.gameObject.tag == "Light") {
			//do stuff

		}
	}

	void OnCollisionEnter2D(Collider2D anything)
	{
		//change direction
	}

	public void shootMonster()
	{
		++hits;
	}

	private void chooseDirection()
	{
		if (!scared) 
		{


		} 
		else 
		{


		}
	}

	private void move()
	{
		current.transform.position += direction * speed * Time.deltaTime;
	}
}
