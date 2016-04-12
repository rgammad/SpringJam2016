using UnityEngine;
using System.Collections;

public class EndScript : MonoBehaviour {

	void OnTriggerEnter2D()
    {

        Application.LoadLevel(Application.loadedLevel);
    }
}
