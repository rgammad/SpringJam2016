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
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
