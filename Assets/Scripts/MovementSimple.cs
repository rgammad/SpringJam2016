using UnityEngine;
using System.Collections;

public class MovementSimple : MonoBehaviour {

    public float moveSpeed;
    public Transform spritetrans;

    private Rigidbody2D rbody;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // Get movement
        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rbody.velocity = inputVector * moveSpeed;

        // Rotate using mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spritetrans.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
	}
}
