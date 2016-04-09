using UnityEngine;
using System.Collections;

// Serializable is required for declaring other classes
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
    public float speed;         // Spped of player movement

    void Update()
    {
        
    }

	void FixedUpdate() 
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Will move the player horizontally
        float moveVertical = Input.GetAxis("Vertical");     // Will move the player vertically

        // Getting the component is required before applying velocity to Player
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector2 movement = new Vector2(moveHorizontal, moveVertical); // Movement of player ship
        rb.velocity = movement * speed; // Apply the speed of player ship when moving

	}

}
