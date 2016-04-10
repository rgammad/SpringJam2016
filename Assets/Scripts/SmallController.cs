using UnityEngine;
using System.Collections;

public class SmallController : MonoBehaviour {

	private bool activate;
	private Vector3 playerPos;
	public float speed;
	private Vector3 direction;

	void Awake()
	{
		activate = false;
		direction = new Vector3 (0, 0, 0);
		playerPos = GameObject.FindGameObjectWithTag ("Player").transform.position;

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		playerPos = GameObject.FindGameObjectWithTag ("Player").transform.position;
		chooseDirection ();
		move ();
			
	}

	private void chooseDirection()
	{
		if (activate) {
			Vector3 newDirection = playerPos - this.transform.position;

			Vector2 rayDir2 = (Vector2)newDirection;
			Debug.DrawRay(this.transform.position, newDirection, Color.red);
			RaycastHit2D hit = Physics2D.Raycast ((Vector2)this.transform.position, rayDir2, 5f);

			if (hit.collider == null || hit.collider.tag == "Player") {
				direction = newDirection;
			} else if (hit.collider.tag == "Wall") {

				direction = pathAround (newDirection);
			}

			//		float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
			//		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			direction = direction.normalized;
		}


	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "Light") {
			activate = true;
		}
	}

	private void move()
	{
		this.transform.position += direction * speed * Time.deltaTime;

	}

	private float getAngle(Vector3 firstAngle, Vector3 secondAngle)
	{
		float result = 0.0f;

		float temp = Vector3.Dot (firstAngle, secondAngle);
		temp /= Vector3.Dot(firstAngle.normalized, secondAngle.normalized);
		temp = Mathf.Acos (temp) * Mathf.Rad2Deg;

		return result;
	}

	private Vector3 pathAround(Vector3 target)
	{
		Vector3 result = Vector3.Cross (target, Vector3.forward);

		int numTests = 40;
		int weight = 10;
		int rayDist = 7;
		float min = Mathf.Infinity;
		float angleDegrees = 360.0f / (float)numTests;

		Vector3[] ARay = new Vector3[numTests];


		ARay[0] = Quaternion.AngleAxis (angleDegrees, Vector3.forward) * new Vector2(direction.x, direction.y);
		Debug.DrawRay(this.transform.position, ARay[0].normalized * rayDist, Color.red);
		Debug.Log (ARay[0]);
		RaycastHit2D hit = Physics2D.Raycast ((Vector2)this.transform.position, ARay[0], rayDist);

		if (hit.collider == null) {
			min = getAngle (direction, ARay [0]) + getAngle (direction, target) / weight;
			result = ARay [0];
		}

		for (int i = 1; i < numTests; ++i) {
			float tempMin = getAngle (direction, ARay [i]) + getAngle (direction, target) * weight;
			ARay[i] = Quaternion.AngleAxis (angleDegrees, Vector3.forward) * new Vector2(ARay[i - 1].x, ARay[i - 1].y);
			Debug.DrawRay(this.transform.position, ARay[i].normalized * rayDist, Color.red);
			hit = Physics2D.Raycast ((Vector2)this.transform.position, ARay[i], rayDist);

			if (tempMin < min && hit.collider == null) {
				min = tempMin;
				result = ARay [i];
			}



		}

		return result;
	}
}
