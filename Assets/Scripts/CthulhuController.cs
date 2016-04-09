using UnityEngine;
using System.Collections;

public class CthulhuController : MonoBehaviour {

	public float health;
	public BoxCollider2D theBox;
	public SpriteRenderer sr;

	void Awake ()
	{
		health = 100.0f;
		theBox.enabled = true;

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
