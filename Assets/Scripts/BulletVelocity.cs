using UnityEngine;
using System.Collections;

public class BulletVelocity : MonoBehaviour {

    public float speed;

    void Start() {
        // Get the rigidbody component before you modify its values
        Rigidbody rb = GetComponent<Rigidbody>();

        // Has the projectile travel forward (in positive direction) along the Z-Axis
        rb.velocity = transform.forward * speed;
    }

    void Update() {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Wall")
            Destroy(gameObject);

        if (other.GetComponent<Collider>().tag == "Targets")
        {
            Destroy(gameObject);
        }
    }
}
