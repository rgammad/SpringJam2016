using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rbody;
    private Animator anim;
    private float angle;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        angle = -90;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rbody.velocity = inputVector * moveSpeed * Time.deltaTime;

        // Tell the animator which way the player is walking
        bool walkingHoriz = true;
        bool walkingVert = true;
        if (inputVector.x > 0.0f)
        {
            anim.SetInteger("walkdir", 1);
        }
        else if (inputVector.x < 0.0f)
        {
            anim.SetInteger("walkdir", 3);
        }
        else
        {
            walkingHoriz = false;
        }
        if (inputVector.y > 0.0f)
        {
            anim.SetInteger("walkdir", 2);
        }
        else if (inputVector.y < 0.0f)
        {
            anim.SetInteger("walkdir", 0);
        }
        else
        {
            walkingVert = false;
        }
        anim.SetBool("walking", walkingHoriz || walkingVert);

        // Rotate using mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetDir = mousePos - transform.position;
        angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
    }

    void Update()
    {
        // Tell the animator which way the torso is facing
        if (angle <= 45 && angle > -45)
        {
            // RIGHT
            anim.SetInteger("facing", 1);
        }
        else if (angle <= -45 && angle > -135)
        {
            // FORWARD
            anim.SetInteger("facing", 0);
        }
        else if (angle <= 135 && angle > 45)
        {
            // BACK
            anim.SetInteger("facing", 2);
        }
        else if (angle <= -135 || angle > 135)
        {
            // LEFT
            anim.SetInteger("facing", 3);
        }
    }
}
