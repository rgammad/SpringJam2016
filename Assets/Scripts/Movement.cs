using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    public float moveSpeed;

    private Rigidbody2D rbody;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        // Raycast Mouse Looking
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 100))
        {
            Vector3 hitPoint = hit.point;
            Vector3 targetDir = hitPoint - transform.position;

            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        rbody.velocity = inputVector * moveSpeed * Time.fixedDeltaTime;
    }
}
