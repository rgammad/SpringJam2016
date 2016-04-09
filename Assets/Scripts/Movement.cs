using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D rbody;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rbody.velocity = inputVector * moveSpeed * Time.fixedDeltaTime;
	}
}
