using UnityEngine;
using System.Collections;

public class BulletVelocity : MonoBehaviour {

    public float speed;
    private Camera viewCamera;
    private Vector2 target;

    void Start() {
        // Get the rigidbody component before you modify its values
        Rigidbody rb = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(target.x + " " + target.y);
        
        
        // Has the projectile travel forward (in positive direction) along the Z-Axis
      //  rb.velocity =  * speed;
    }

    void Update() {
        float step = speed * Time.deltaTime;
       // Vector3 MousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.x);
        //transform.position = Vector3.MoveTowards(transform.position, Input.mousePosition, step);
        
        //Vector3 target = new Vector3(mouse.x, mouse.y, mouse.z);

        transform.position = Vector2.MoveTowards(transform.position, target, step);
        if ((transform.position.x == target.x) && (transform.position.y == target.y ))
        {
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)

    {
        
        if (other.gameObject.tag == "Wall")
            Destroy(gameObject);

        if (other.gameObject.tag == "Smalls")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);

        }
    }
}
