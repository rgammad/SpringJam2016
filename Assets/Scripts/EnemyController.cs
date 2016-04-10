using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public int health = 100;
    private GameObject player;
    public Transform target;
    public float moveSpeed;
    public int rotationSpeed;
    private Transform myTransform;

    // Field Of View Script
    private FieldOfView fieldOfView;

    void Awake()
    {
        myTransform = transform;
        fieldOfView = this.gameObject.GetComponent<FieldOfView>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
    }

    void Update()
    {
        //Look at target
        //myTransform.rotation = Quaternion.Slerp(myTransform.rotation, 
        //                                        Quaternion.LookRotation(target.position - myTransform.position), 
        //                                        rotationSpeed * Time.deltaTime);

        if (canSeePlayer())
        {
            //Debug.Log("Spotted Player");
            transform.LookAt(target);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }

    }

    private bool canSeePlayer()
    {
        if (fieldOfView.visibleTargets.Count > 0)
        {
            for (int i = 0; i < fieldOfView.visibleTargets.Count; i++)
            {
                if (fieldOfView.visibleTargets[i].tag == "Player")
                    return true;
            }
        }

        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Bolt")
        {
            health -= 10;
            if (health <= 0)
                Destroy(gameObject);
        }
    }
}
