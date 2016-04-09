using UnityEngine;
using System.Collections;

public class CthulhuController : MonoBehaviour {

	private int hits;
	public float speed;

	void Awake ()
	{
		hits = 0;


	}
	// Use this for initialization
	void Start () {
		InvokeRepeating ("chooseDirection", 2f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
	
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

	}

	private void getScared()
	{
		speed = 40;
	}

	private void chooseDirection()
	{

	}

	private void move()
	{

	}
}
