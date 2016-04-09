using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    //public int minDistance;
    //public int maxDistance;
    private Transform myTransform;

    // Field of Vision
    private GameObject player;
    public float fieldOfViewRange;
    public float minPlayerDetectDistance;
    public float rayRange;

    void Awake()
    {
        myTransform = transform;
    }

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        target = player.transform;

        //maxDistance = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawLine(target.position, myTransform.position, Color.green);

        //Look at target
        /*
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, 
                                                Quaternion.LookRotation(target.position - myTransform.position), 
                                                rotationSpeed * Time.deltaTime);
        */

        
        if (canSeePlayer())
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * Time.deltaTime);
        }

    }

    private bool canSeePlayer()
    {
        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - transform.position;
        Debug.DrawRay(transform.position, rayDirection, Color.red);
        //Debug.DrawRay(transform.position, transform.forward, Color.red);
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        /*
        if (Physics.Raycast (transform.position, rayDirection, out hit))
        { 
            // If the player is very close behind the enemy and not in view the enemy will detect the player
            if((hit.transform.tag == "Player") && (distanceToPlayer <= minPlayerDetectDistance))
            {
                Debug.Log("Caught player sneaking up behind!");
                return true;
            }
        }
        */

        float fieldOfVision = Vector3.Angle(rayDirection, transform.forward);
        //float fieldOfVision = Vector3.Angle(transform.position, transform.forward);
        //Debug.Log(fieldOfVision);
        if (fieldOfVision < fieldOfViewRange)
        {
            // Detect if player is within the field of view
            if (Physics.Raycast (transform.position, rayDirection, out hit, rayRange))
            {
                if (hit.collider.name == "Player")
                {
                    Debug.Log("Can see player");
                    return true;
                }
                else
                {
                    Debug.Log("Can not see player");
                    return false;
                }
             }
         }

        return false;
    }

}
