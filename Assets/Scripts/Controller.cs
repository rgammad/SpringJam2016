using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float moveSpeed = 6;
    

	private Rigidbody myRigidbody;
    private Camera viewCamera;
    private Vector3 velocity;
    private GameObject Cthulhu;
    private CthulhuController CthulhuScript;

	public int energyRegen = 5;
	public float maxHealth = 100.0f;

    

    // Firing
    public GameObject projectile;   // The game object that will be instantiated
    public int energyLeft = 100;



    public Light lt;

    public float fireRate;  // The rate of fire for the player
    private float nextFire; // The time it will take for the next player to fire dhb\Jll
    void Start ()
    {
		
		viewCamera = Camera.main;
        energyLeft--;
        //Cthulhu = GameObject.FindGameObjectWithTag("Cthulhu");
        //CthulhuScript = Cthulhu.GetComponent<CthulhuController>();
       
	}

	void Update ()
    {
		//Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
		//transform.LookAt (mousePos + Vector3.up * transform.position.y);

        // Input.GetButton("Fire1") - Fires a shot when left clicking the mouse
        // Time.time > nextFire - if enough time has passed since the last time the player has fired, player can fire again
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            lt.intensity -= .08f;

			lt.intensity -= 8/maxHealth;

            //Instantiate(GameObject, Position, Rotation);
            Instantiate(projectile, this.gameObject.transform.position, Quaternion.identity);    // Clones a game object and gives it its position and rotation
            
        }

    }

    public void reduceEnergy()
    {
        energyLeft--;
        Debug.Log(energyLeft);
        if (energyLeft <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void regenEnergy()
    {
        energyLeft += energyRegen;
    }

    void FixedUpdate()
    {
       
    }

}