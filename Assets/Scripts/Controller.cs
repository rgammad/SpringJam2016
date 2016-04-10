using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float moveSpeed = 6;

	private Rigidbody myRigidbody;
    private Camera viewCamera;
    private Vector3 velocity;

    // Firing
    public GameObject projectile;   // The game object that will be instantiated
    public Transform shotSpawn;     // Where the game object will be instantiated

    public float fireRate;  // The rate of fire for the player
    private float nextFire; // The time it will take for the next player to fire again

    void Start ()
    {
		myRigidbody = GetComponent<Rigidbody> ();
		viewCamera = Camera.main;
	}

	void Update ()
    {
		Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
		transform.LookAt (mousePos + Vector3.up * transform.position.y);
		velocity = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized * moveSpeed;

        // Input.GetButton("Fire1") - Fires a shot when left clicking the mouse
        // Time.time > nextFire - if enough time has passed since the last time the player has fired, player can fire again
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            // Instantiate(GameObject, Position, Rotation);
            Instantiate(projectile, shotSpawn.position, shotSpawn.rotation);    // Clones a game object and gives it its position and rotation
        }
    }

    void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}