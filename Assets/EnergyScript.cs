using UnityEngine;
using System.Collections;

public class EnergyScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Controller>().regenEnergy();
            Destroy(this.gameObject);
        }
    }
}
